using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebGrabDemo.WebGrabMgmt
{
    public class WebGrabProcessor
    {
        public string GrabContent(string inputUrl)
        {
            using (var webClient = new WebClient())
            {
                Uri url = new Uri(inputUrl);
                webClient.Encoding = System.Text.Encoding.UTF8;
                string html = webClient.DownloadString(url);
                return html;
            }
        }
    }
}