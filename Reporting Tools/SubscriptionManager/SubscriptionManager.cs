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
        ServiceState curState = ServiceState.Disconnected;
        ReportingService rs = new ReportingService();

        public SubscriptionManager()
        {
            InitializeComponent();
        }

        private void SubscriptionManager_Load(object sender, EventArgs e)
        {
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            
            // set the event handlers. Should do this in the constructor?
            rs.ListSubscriptionsCompleted += SubscriptionLoadComplete;
            rs.FireEventCompleted += triggerSubscriptionComplete;
            
            // get the subscription list...
            changeState(ServiceState.LoadingList);
            rs.ListSubscriptionsAsync(null, null);
        }

        private void SubscriptionLoadComplete(object sender, ListSubscriptionsCompletedEventArgs e)
        {
            Subscription[] subList = e.Result;
            mainSubTree.AddSubscription(subList);

            // expand the root node only. leave the subscriptions hidden
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
                try {
                    changeState(ServiceState.LoadingEvent);
                    rs.FireEventAsync(curSub.EventType, curSub.SubscriptionID);
                    changeState(ServiceState.Connected);
                } catch {
                    changeState(ServiceState.Error);
                }
            }
        }

        // change the state varible, set any messages etc
        private void changeState(ServiceState newState)
        {
            if(newState == ServiceState.LoadingList) {
                statusLabel.Text = "Loading...";
            } else if(newState == ServiceState.Connected) {
                statusLabel.Text = "Connected to <SERVERNAME>";
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

        private void triggerSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subscription curSub = mainSubTree.SelectedNode.Tag as Subscription;
            triggerSubscription(curSub);
        }



        private void triggerSubscriptionComplete(object sender, EventArgs e)
        {
            changeState(ServiceState.Connected);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadSubscriptions();
        }

        private void refreshToolButton_Click(object sender, EventArgs e)
        {
            reloadSubscriptions();
        }
    }



    // specilized treeview for showing the subscriptions on a given server
    public class SubscriptionTree : TreeView {
        const string REPORT_ICON = "Report.png";
        const string SUB_ICON = "Subscription.png";


        // just add a root nodes called "reports" or something similar
        public SubscriptionTree() : base() 
        {
            if(this.Nodes.Find("Root", false).Length == 0) {
                this.Nodes.Add("Root", "Reports");
            }
        }

        public void AddSubscription(Subscription[] subList) 
        {
            foreach(Subscription curSub in subList) {
                this.AddSubscription(curSub);
            }
        }

        // adds a subscription to the treeview, checking to see if the report
        // it is from is already there etc.
        public void AddSubscription(Subscription curSub) 
        {
            // does this report exist in the list already? if not then add it
            if(this.Nodes.Find(curSub.Report, true).Length == 0) {
                TreeNode reportNode = new TreeNode(curSub.Report);
                
                reportNode.Name = curSub.Report;
                reportNode.ImageKey = REPORT_ICON;
                reportNode.SelectedImageKey = REPORT_ICON;

                this.Nodes["Root"].Nodes.Add(reportNode);
            }
        
            // create the new subscription node, and associate the actual subscription object
            // with it
            TreeNode newNode = new TreeNode(curSub.Description);
            newNode.Tag = curSub;
            newNode.ImageKey = SUB_ICON;
            newNode.SelectedImageKey = SUB_ICON;

            this.Nodes["Root"].Nodes[curSub.Report].Nodes.Add(newNode);
        }
    }
}