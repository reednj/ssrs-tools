using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ReportingTools.Common;
using ReportingTools.Common.ReportService;

namespace ReportingTools.SubscriptionManager
{
    public partial class SubscriptionTree : TreeView
    {
        const string REPORT_ICON = "Report.png";
        const string SUB_ICON = "Subscription.png";


        // just add a root nodes called "reports" or something similar
        public SubscriptionTree()
            : base()
        {
            InitializeComponent();

            this.Nodes.Clear();
            this.Nodes.Add("Root", "Reports");         
        }

        public void AddSubscription(Subscription[] subList)
        {
            foreach (Subscription curSub in subList)
            {
                this.AddSubscription(curSub);
            }
        }

        // adds a subscription to the treeview, checking to see if the report
        // it is from is already there etc.
        public void AddSubscription(Subscription curSub)
        {
            // does this report exist in the list already? if not then add it
            if (this.Nodes.Find(curSub.Report, true).Length == 0)
            {
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

            // set the color, if the subscription has probably failed recently
            if (curSub.Status.Contains("Failure"))
            {
                newNode.BackColor = Color.Pink;
            }

            this.Nodes["Root"].Nodes[curSub.Report].Nodes.Add(newNode);
        }
    }
}
