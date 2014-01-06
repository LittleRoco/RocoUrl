using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace xlkshorturl.Data
{
    [ComVisible(true)]
    public static class ShortUrlController
    {
        private static string ConnectionString = global::xlkshorturl.Properties.Resources.Connection;
        //private static SqlConnection con = new SqlConnection(ConnectionString);
        private static SqlCommand cmd = new SqlCommand();
        //id,urlid,urltitle,url
        public static bool AddUrl(string id,string title,string url)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into urltransfer(urlid,urltitle,url) values (@id,@title,@url);";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@url", url));
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetUrl(string id)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select url from urltransfer where urlid=@id;";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr=cmd.ExecuteReader();
                string s="";
                while (dr.Read())
                {
                    s = dr["url"].ToString();
                }
                con.Close();
                return s;
            }
            catch
            {
                return "";
            }
        }
        public static List<ShortUrlObject> GetAllUrls()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from urltransfer;";
                cmd.Parameters.Clear();
                SqlDataReader dr = cmd.ExecuteReader();
                List<ShortUrlObject> URLList = new List<ShortUrlObject>();
                while (dr.Read())
                {
                    ShortUrlObject tmp = new ShortUrlObject();
                    tmp.urlid = dr["urlid"].ToString();
                    tmp.urltitle = dr["urltitle"].ToString();
                    tmp.url = dr["url"].ToString();
                    URLList.Add(tmp);
                }
                con.Close();
                return URLList;
            }
            catch
            {
                return null;
            }
        }
    }
}
