using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace xlkshorturl.Web
{
    [ComVisible(true)]
    public interface IDocument
    {
        string title { get; set; }
        string doctype { get;  }
        string charset { get;  }
        string body { get; set; }
    }
}
