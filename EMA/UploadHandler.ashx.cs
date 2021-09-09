using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMA
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    HttpPostedFile postedFile = files[i];
                    string filename = context.Server.MapPath("~/Content/Upload/" + System.IO.Path.GetFileName(files[i].FileName));
                    postedFile.SaveAs(filename);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}