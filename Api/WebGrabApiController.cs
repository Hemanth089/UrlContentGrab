using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGrabDemo.Models;
using WebGrabDemo.WebGrabMgmt;
using WebGrease;

namespace WebGrabDemo.Api
{
    public class WebGrabApiController : ApiController
    {
        /// <summary>
        /// Grab content of URL
        /// </summary>
        /// <param name="input">Pass URL</param>
        /// <returns></returns>
        [HttpPost]
        public ContentModel LoadUrl([FromBody] string url)
        {
            try
            {
                ContentInfo contentInfo = new ContentInfo();
                ContentModel contentResponse = contentInfo.GetContentInfo(url);
                return contentResponse;
            }
            catch (Exception ex)
            {
                //Log Exceptions here
                return null;

            }
        }
    }
}