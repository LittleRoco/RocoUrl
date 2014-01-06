using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace xlkshorturl.Web
{

    [ComVisible(true)]
    public class ShortUrlHandlerFactory : IHttpHandlerFactory
    {
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            return new ShortUrlHandler();
        }

        public void ReleaseHandler(IHttpHandler handler)
        {

        }
    }
}
