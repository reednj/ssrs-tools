using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using RenderReport.ReportService;

namespace RenderReport
{
    public class ReportTree : TreeView
    {

        public ReportTree() : base() 
        {
            // add the root node. Check if it has already been created in the vs designer
            if(this.Nodes["Root"] == null) {
                this.Nodes.Add("Root", "Home");
            }
        }

        public void AddReport(CatalogItem curReport)
        {
            //// split the path up into its parts
            //// path looks something like /AtomReport/Management/Report Name
            string[] pathItems = curReport.Path.Split('/');
            TreeNode curNode = this.Nodes["Root"];

            foreach(string curFolder in pathItems) {
                if(curFolder.Length > 0) {
                    
                    // does that folder exist already?
                    TreeNode[] nodeList = curNode.Nodes.Find(curFolder, false);
                    
                    if(nodeList.Length == 0) {
                        curNode = curNode.Nodes.Add(curFolder, curFolder);
                    } else {
                        curNode = nodeList[0];
                    }
                }
            }

            // curNode should be pointing to the final leaf of the item we addded
            // so set the tag...
            curNode.Tag = curReport;
            curNode.ImageIndex = 1;
            
        }



    }
}
