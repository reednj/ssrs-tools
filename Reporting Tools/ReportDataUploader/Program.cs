/*
 * The purpose of this application is to upload large amounts of data to the report
 * server. I need to do this for testing purposes.
 * 
 * Nathan Reed, 2010-08-06
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using ReportingTools.Common;
using ReportingTools.Common.ReportService;

namespace ReportDataUploader
{
    class Program
    {
        static Random rand = new Random();
        static ReportingService rs = new ReportingService();

        static void Main(string[] args)
        {
            
            Console.WriteLine("SSRS Random Data Uploader - Nathan Reed (c) 2010");
            
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = SSRSUri.ParseString("hydrogen/nate").ToUrl();

            string[] FolderList = CreateFolders(25, "/Test");
            CreateRandomReports(@"C:\Dev\Temp\test-1.rdl", FolderList, 100);
        }

        static void CreateRandomReports(string RDLFile, string[] Folders, int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                string CurFolder = Folders[rand.Next(0, Folders.Length-1)];
                CreateRandomReport(RDLFile, CurFolder);

            }
        }

        static void CreateRandomReport(string RDLFile, string CreateInFolder)
        {
            Byte[] ReportData = File.ReadAllBytes(RDLFile);
            string itemName = "report-" + rand.Next().ToString();
            rs.CreateReport(itemName, CreateInFolder, true, ReportData, null);

            Console.WriteLine("Creating Report: '{0}/{1}'", CreateInFolder, itemName);
        }

        static string[] CreateFolders(int Count, string RootFolder)
        {
            string InPath = RootFolder;
            List<string> FolderList = new List<string>();


            for (int i = 0; i < Count; i++)
            {
                string FolderName = "folder-" + rand.Next().ToString();
                rs.CreateFolder(FolderName, InPath, null);
                FolderList.Add(InPath + "/" + FolderName);

                // maybe we want to create another folder inside this one?
                // we will decicde randomly.
                InPath = (rand.Next() % 2 == 0) ? InPath + "/" + FolderName : RootFolder;

                Console.WriteLine("Creating Folder: '{0}/{1}'", InPath, FolderName);
            }

            return FolderList.ToArray();
        }

    }
}
