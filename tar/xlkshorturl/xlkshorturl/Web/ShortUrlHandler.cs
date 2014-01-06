using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Web;
using xlkshorturl.Data;
using System.IO;
using System.Security.Cryptography;

namespace xlkshorturl.Web
{
    [ComVisible(true)]
    public class ShortUrlHandler:IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request.Path;
            string realurl="";
            switch(url.TrimStart('/'))
            {
                case "":
                case "index":
                    #region index
                    WebPage index = new WebPage();
                    index.title = "小洛克短网址服务";
                    index.body = File.ReadAllText(@"D:\inetpub\webroot\shorten\default.html");
                    context.Response.StatusCode = 200;
                    context.Response.ContentEncoding = Encoding.UTF8;
                    context.Response.ContentType = "text/html";
                    context.Response.Write(index.ToString());
                    break;
                    #endregion
                case "sorry":
                    #region sorry
                    WebPage notfound = new WebPage();
                    notfound.title = "页面不存在";
                    notfound.body = "HTTP 404 找不到页面<br/>"+
                        "原因：短地址解析失败";
                    context.Response.StatusCode = 404;
                    context.Response.ContentEncoding = Encoding.UTF8;
                    context.Response.ContentType = "text/html";
                    context.Response.Write(notfound.ToString());
                    break;
                    #endregion
                case "add":
                    #region add
                    if (context.Request.HttpMethod.ToLower() == "post")
                    {
                        string id, title, realurl2;
                        id = context.Request.Form["urlid"];
                        title = context.Request.Form["urltitle"];
                        realurl2 = context.Request.Form["url"];
                        if (id == "")
                        {
                            id = new Random().Next(0, int.MaxValue).ToString();
                        }
                        bool ret=ShortUrlController.AddUrl(id, title, realurl2);
                        if (ret)
                        {
                            context.Response.StatusCode = 200;
                            context.Response.ContentEncoding = Encoding.UTF8;
                            context.Response.ContentType = "text/html";
                            string s = "http://xlk.me/" + id;
                            context.Response.Write("创建成功。地址: <a href='"+s+"'>"+s+"</a>");
                        }
                        else
                        {
                            context.Response.StatusCode = 200;
                            context.Response.ContentEncoding = Encoding.UTF8;
                            context.Response.ContentType = "text/html";
                            context.Response.Write("创建失败");
                        }
                    }
                    else
                    {
                        WebPage addshort = new WebPage();
                        addshort.title = "添加短网址解析";
                        addshort.body = File.ReadAllText(@"D:\inetpub\webroot\shorten\add.html");
                        context.Response.StatusCode = 200;
                        context.Response.ContentEncoding = Encoding.UTF8;
                        context.Response.ContentType = "text/html";
                        context.Response.Write(addshort.ToString());
                    }
                    break;
                    #endregion
                #region LIST
                /*case "list":
                    #region list
                    WebPage list = new WebPage();
                    list.title = "已启用的短网址列表";
                    list.body = "";
                    context.Response.StatusCode = 200;
                    context.Response.ContentEncoding = Encoding.UTF8;
                    context.Response.ContentType = "text/html";
                    context.Response.Write(list.ToString());
                    break;
                    #endregion*/
                #endregion
                case "query":
                    #region query
                    WebPage query = new WebPage();
                    query.title = "小洛克短网址服务";
                    string id2 = context.Request.Form["urlid"];
                    string realurl3;
                    realurl3 =ShortUrlController.GetUrl(id2);
                    if (realurl3 == ""||id2=="")
                    {
                        query.body = "解析失败";
                    }
                    else
                    {
                        query.body = "解析成功。地址是: <a href='" + realurl3 + "'>" + realurl3 + "</a>";
                    }
                    context.Response.StatusCode = 200;
                    context.Response.ContentEncoding = Encoding.UTF8;
                    context.Response.ContentType = "text/html";
                    context.Response.Write(query.ToString());
                    break;
                    #endregion
                default:
                    #region default
                    realurl =ShortUrlController.GetUrl(url.TrimStart('/'));
                    if (realurl == "")
                    {
                        //context.Response.StatusCode = 404;
                        context.Response.RedirectPermanent("~/sorry");
                    }
                    else
                    {
                        //context.Response.StatusCode = 301;
                        context.Response.RedirectPermanent(realurl);
                    }
                    break;
                    #endregion
            }
        }
    }

}
