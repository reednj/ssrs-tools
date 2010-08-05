/*
 * 
 * 
 * Nathan Reed, 2009-04-10
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ReportingTools.Common;
using ReportingTools.Common.ReportService;

namespace ReportingTools.SubscriptionManager
{
    public partial class SubscriptionManager : Form
    {
        bool _loadComplete = false;
        ServiceState curState = ServiceState.Disconnected;
        ReportingService rs = new ReportingService();
        BackgroundWorker Subscription_Worker;
        SSRSUri ServerUrl = null;

        SubscriptionJob JobStatus = null;

        public SubscriptionManager()
        {
            InitializeComponent();
        }

        private void SubscriptionManager_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

            // set the event handlers
            rs.ListSubscriptionsCompleted += SubscriptionLoadComplete;
            rs.FireEventCompleted += triggerSubscriptionComplete;
        }

        private void SubscriptionManager_Activated(object sender, EventArgs e)
        {
            if (this._loadComplete == false)
            {
                this._loadComplete = true;

                // we must start the list subscriptions thing as a background worker, 
                // the built in async method connects first before returning, this can take
                // 5-10 seconds, which is unacceptably long.
                Subscription_Worker = new BackgroundWorker();
                Subscription_Worker.DoWork += new DoWorkEventHandler(Subscription_Worker_DoWork);
                Subscription_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Subscription_Worker_RunWorkerCompleted);

                this.RunConnectDialog(true);
            }
        }

        void Subscription_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the subscription list...
            changeState(ServiceState.LoadingList);
            e.Result = rs.ListSubscriptions(null, null);
        }

        void Subscription_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LoadSubscriptions((Subscription[])e.Result);
        }

        private void SubscriptionLoadComplete(object sender, ListSubscriptionsCompletedEventArgs e)
        {
            this.LoadSubscriptions(e.Result);
        }

        private void LoadSubscriptions(Subscription[] subList)
        {
            mainSubTree.AddSubscription(subList);            
            mainSubTree.ExpandAll();

            changeState(ServiceState.Connected);
        }

        private void mainSubTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateDetails(e.Node.Tag as Subscription);
        }

        private void PopulateDetails(Subscription curSub)
        {
            // set the details pane labels.
            // if we have not been sent a valid sub object, then just set them all to
            // "-"
            if(curSub != null) {
                subDescLabel.Text = curSub.Description;
                subLastRanLabel.Text = curSub.LastExecuted.ToString();
                subLastResultLabel.Text = curSub.Status;
            } else {
                subDescLabel.Text = "-";
                subLastRanLabel.Text = "-";
                subLastResultLabel.Text = "-";
            }
        }

        private void reloadSubscriptions()
        {
            // change the state, clear the list and trigger the method to get the list of subscriptions.
            changeState(ServiceState.LoadingList);
            mainSubTree.Nodes["Root"].Nodes.Clear();
            rs.ListSubscriptionsAsync(null, null);
        }

        private void triggerSubscription(Subscription curSub)
        {
            // trigger the currently selected subscription
            if(curSub != null) {
                changeState(ServiceState.LoadingEvent);
                statusLabel.Text = "Queueing Subscription...";
                rs.FireEventAsync(curSub.EventType, curSub.SubscriptionID);

                // we set this here, even though it should really go in the trigger complete section...
                JobStatus = new SubscriptionJob(curSub, rs.Credentials);
            }
        }
        
        private void triggerSubscriptionComplete(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error == null) {
                changeState(ServiceState.Connected);
                statusLabel.Text = "Starting Subscription...";

                // we want to check on the subscription every 5 seconds to make sure that it actually
                // starts. We do this by looking at the LastExecuted date, and checking for when it
                // changes.
                StatusTimer.Enabled = true;
            } else {
                // could not fire the subscription for some reason...
                changeState(ServiceState.Error, e.Error.Message);
            }
        }


        private void changeState(ServiceState newState)
        {
            this.changeState(newState, null);
        }

        // change the state varible, set any messages etc
        private void changeState(ServiceState newState, string Message)
        {
            statusLabel.Image = null;

            if(newState == ServiceState.LoadingList) {
                statusLabel.Text = "Loading...";
            } else if(newState == ServiceState.Connected) {
                statusLabel.Text = String.Format("Connected to '{0}'", this.ServerUrl.FullName);
            } else if(newState == ServiceState.Error) {
                if (Message != null)
                {
                    // webservice errors have weird messages. We need to parse the error to get rid of that
                    // shit
                    Message = Message.Split(new string[] {"--->"}, 2, StringSplitOptions.None)[0];
                    statusLabel.Image = Properties.Resources.exclamation;
                    statusLabel.Text = String.Format("Error: {0}", Message);
                }
                else
                {
                    statusLabel.Text = "Could not complete action";
                }
            }

            curState = newState;
        }



        /*
         * Right click menu event handlers 
         */
        private void mainSubTree_MouseUp(object sender, MouseEventArgs e)
        {
            // show the right click menu..
            if(e.Button == MouseButtons.Right) {
                // select the node they just clicked on. Don't know why this doesn't happen
                // by default
                mainSubTree.SelectedNode = mainSubTree.GetNodeAt(e.X, e.Y);
                
                // check the selecteditem to see whether they should be able to trigger a subscription
                // or not.
                if(mainSubTree.SelectedNode != null && mainSubTree.SelectedNode.Tag != null) {
                    triggerSubscriptionToolStripMenuItem.Enabled = true;
                } else {
                    triggerSubscriptionToolStripMenuItem.Enabled = false;
                }

                subTreeMenu.Show(mainSubTree, new Point(e.X, e.Y));
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadSubscriptions();
        }

        private void refreshToolButton_Click(object sender, EventArgs e)
        {
            reloadSubscriptions();
        }

        private void ConnectToolButton_Click(object sender, EventArgs e)
        {
            this.RunConnectDialog(false);
        }

        private void RunConnectDialog(bool AutoLogin)
        {
            LoginForm lf = new LoginForm(AutoLogin);
            if (lf.ShowDialog() == DialogResult.OK)
            {
                // disconnect. TODO: a general method to set the ui on a state change.
                curState = ServiceState.Disconnected;
                mainSubTree.Nodes["Root"].Nodes.Clear();

                // if the user click ok on the connection dialog box, set the rs url
                // and start getting the data. Otherwise to nothing...
                this.ServerUrl = lf.ServerUrl;
                rs.Url = this.ServerUrl.ToUrl();
                Subscription_Worker.RunWorkerAsync();
            }
        }

        private void triggerToolButton_Click(object sender, EventArgs e)
        {
            Subscription curSub = mainSubTree.SelectedNode.Tag as Subscription;
            this.triggerSubscription(curSub);
        }

        private void triggerSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subscription curSub = mainSubTree.SelectedNode.Tag as Subscription;
            this.triggerSubscription(curSub);
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            //// TODO THIS CODE NEEDS TO BE LOCKED, in case the timer fires while we are already getting
            //// the details. Or maybe just disable the timer or something?

            if (this.JobStatus != null)
            {
                this.JobStatus.Refresh();

                // we only wait until the job is running, then stop monitoring...
                if (this.JobStatus.State == SubscriptionJobState.Running)
                {
                    statusLabel.Text = String.Format("Subscription Triggered: {0}", this.JobStatus.Subscription.LastExecuted);
                    
                    this.JobStatus = null;
                    StatusTimer.Enabled = false;

                    // update the last ran data as well, if we have that subscription selected still
                    //if (mainSubTree.SelectedNode.Tag != null && ((Subscription)mainSubTree.SelectedNode.Tag).SubscriptionID == this.JobStatus.Subscription.SubscriptionID)
                    //{
                    //    subLastRanLabel.Text = this.JobStatus.Subscription.LastExecuted.ToShortTimeString();
                    //    subLastResultLabel.Text = this.JobStatus.Subscription.Status;
                    //}
                }
            }
            else
            {
                StatusTimer.Enabled = false;
            }
        }

    }

    public class SubscriptionJob
    {
        RsHelper rsh;

        Subscription _subscription;
        Job _job;
        SubscriptionJobState _state;

        int jobRequestCount = 0;

        public Subscription Subscription { get { return _subscription; } set { _subscription = value; } }
        public Job Job { get { return _job; } set { _job = value; } }
        public SubscriptionJobState State { get { return _state; } }

        public SubscriptionJob(Subscription s, System.Net.ICredentials RsCredentials)
        {
            this.rsh = new RsHelper(RsCredentials);
            this.Subscription = s;
            this._state = SubscriptionJobState.Starting;
        }

        public void Refresh()
        {
            if (this._state == SubscriptionJobState.Starting)
            {
                // refresh the subscription, there is no job yet
                Subscription s = rsh.RefreshSubscription(this.Subscription);

                if (this.Subscription.LastExecuted != s.LastExecuted)
                {
                    this._state = SubscriptionJobState.Running;
                }

                this.Subscription = s;

            }
            else if (this._state == SubscriptionJobState.Running)
            {
                if (this.Job != null)
                {
                    this.Job = rsh.RefreshJob(this.Job);

                    if (this.Job == null)
                    {
                        this._state = SubscriptionJobState.Finished;
                    }
                }
                else
                {
                    // we are getting the job data for the first time.
                    this.jobRequestCount++;
                    this.Job = rsh.GetSubscriptionJob(this.Subscription);

                    if (this.Job == null && this.jobRequestCount >= 3)
                    {
                        this._state = SubscriptionJobState.Finished;
                    }
                }
                
            }
        }
        
    }

    public enum SubscriptionJobState
    {
        None,
        Starting,
        Running,
        CancelPending,
        Finished
    }

    public class RsHelper
    {
        ReportingService rs = new ReportingService();

        public RsHelper(System.Net.ICredentials RsCredentials)
        {
            rs.Credentials = RsCredentials;
        }

        public Subscription RefreshSubscription(Subscription curSub)
        {
            return RefreshSubscription(curSub, rs);
        }

        public Job RefreshJob(Job curJob)
        {
            return RefreshJob(curJob, rs);
        }

        public Job GetSubscriptionJob(Subscription s)
        {
            return GetSubscriptionJob(s, rs);
        }

        public static Subscription RefreshSubscription(Subscription curSub, ReportingService rs)
        {
            // there is no method to get an individual subscription apart from
            // 'getsubscriptionproperties' and this is too hard to use.
            Subscription[] sl = rs.ListSubscriptions(curSub.Path, null);
            foreach (Subscription s in sl)
            {
                if (s.SubscriptionID == curSub.SubscriptionID)
                {
                    return s;
                }
            }

            return curSub;
        }

        public static Job RefreshJob(Job curJob, ReportingService rs)
        {
            Job[] jl = rs.ListJobs();

            foreach (Job j in jl)
            {
                if (j.JobID == curJob.JobID)
                {
                    return j;
                }
            }

            return null;
        }

        // given a subscription, search through the job list and see
        // if there is anything there that matches
        public static Job GetSubscriptionJob(Subscription s, ReportingService rs)
        {
            if (s == null)
            {
                return null;
            }

            Job[] jl = rs.ListJobs();

            foreach (Job j in jl)
            {
                if (j.StartDateTime == s.LastExecuted && j.Path == s.Path)
                {
                    return j;
                }
            }

            return null;
        }
    }
}