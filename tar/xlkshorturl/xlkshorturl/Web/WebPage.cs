using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace xlkshorturl.Web
{
    [ComVisible(true)]
    public class WebPage:IDocument
    {
        public string title
        {
            get;
            set;
        }

        public string doctype
        {
            get { return "html"; }
        }

        public string charset
        {
            get { return "utf-8"; }
        }

        public string body
        {
            get;
            set;
        }
        public override string ToString()
        {
            string html = "";
            html += "<!DOCTYPE {0}>\r\n<head>\r\n";
            html += "<title>{1}</title>\r\n";
            html += "<meta http-equiv=\"Content-Type\" content=\"{2}\">\r\n</head>\r\n";
            html += "<body>{3}</body></html>";
            return string.Format(html, doctype, title, charset, body);
        }
    }
}
