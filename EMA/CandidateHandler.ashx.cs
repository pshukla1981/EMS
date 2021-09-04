using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EMA.Business.Factory.ViewModels;
using EMA.Business.Factory.Repository;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace EMA
{
    /// <summary>
    /// Summary description for CandidateHandler
    /// </summary>
    public class CandidateHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            List<string> lst = new CandidateRepository().GetCandidate(term);
            JavaScriptSerializer js = new JavaScriptSerializer();
            // js.Serialize(lst);
            //context.Response.ContentType = "text/plain";
            context.Response.Write(js.Serialize(lst));
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