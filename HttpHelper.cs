using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Sixi.Network.Utils
{
    public class HttpHelper
    {
        public static string HttpRequest(string url, Encoding encoding)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 60 * 1000;
                request.Method = "GET";
                //得到处理结果                              
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
                string result = myStreamReader.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
