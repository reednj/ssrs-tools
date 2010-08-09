using System;
using System.Collections.Generic;
using System.Text;

// we use this to enable extension methods when targeting
// .net 2.0.
// from: http://csharpindepth.com/Articles/Chapter1/Versions.aspx
namespace System.Runtime.CompilerServices
{
    [AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public class ExtensionAttribute : Attribute
    {
    }
}

namespace ReportingTools.Common
{

    public static class CommonExtensions
    {
        public static string ShortMessage(this Exception ex)
        {


            if (ex.GetType() == typeof(System.Web.Services.Protocols.SoapException))
            {
                return ex.Message.Split(new string[] { "--->" }, 2, StringSplitOptions.None)[0];
            }
            else
            {
                return ex.Message;
            }
            
        }
    }

    public enum ServiceState {
        Disconnected,
        Connected,
        LoadingList,
        LoadingEvent,
        Downloading,
        Error       
    }

    // sets a url specifically for reporting services
    public class SSRSUri
    {
        private string _serverName = null;
        private string _instanceName = null;

        public string ServerName { get { return _serverName; } set { _serverName = value; } }
        public string InstanceName { get { return _instanceName; } set { _instanceName = value; } }
        public string WebServiceUrl { get { return this.ToUrl(); } }
        public string FullName
        {
            
            get
            {
                return this.InstanceName == null ? this.ServerName : String.Format("{0}\\{1}", this.ServerName, this.InstanceName);
            }
        }


        public SSRSUri()
        {
        }

        public SSRSUri(string ServerName)
        {
            this.ServerName = ServerName;
        }

        public SSRSUri(string ServerName, string InstanceName)
        {
            this.ServerName = ServerName;
            this.InstanceName = InstanceName;
        }

        // takes a string containing the servername and the instance name
        public static SSRSUri ParseString(string ServerString)
        {
            // we need to split this along the '\' character to get the instance
            string[] ServerDetails = ServerString.Split(new char[] { '/', '\\' }, 2);
            if (ServerDetails.Length > 1)
            {
                return new SSRSUri(ServerDetails[0], ServerDetails[1]);
            }
            else
            {
                return new SSRSUri(ServerDetails[0]);
            }
        }

        public string ToUrl()
        {
            if (this.ServerName == null)
            {
                throw new InvalidOperationException("You must set a ServerName to generate a url");
            }

            if (this.InstanceName == null)
            {
                return String.Format("http://{0}/reportserver/reportservice.asmx", this.ServerName);
            }
            else
            {
                return String.Format("http://{0}/reportserver${1}/reportservice.asmx", this.ServerName, this.InstanceName);
            }
        }
    }
}
