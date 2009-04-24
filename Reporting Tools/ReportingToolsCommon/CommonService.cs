using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingTools.Common
{
    public enum ServiceState {
        Disconnected,
        Connected,
        LoadingList,
        LoadingEvent,
        Error       
    }
}
