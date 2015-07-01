﻿/*
 * 
 * Author: Dangzhang
 * Create Date: unknown
 * Description:
 * This is a traceroute GUI tool for windows users. It uses a Taobao ip whois api to resolve an ip to it's geo-info.
 * This program uses a traceroute Helper from http://www.fluxbytes.com/csharp/tracert-implementation-in-c/
 * Thanks to Halo. :)
 * Have fun.
 * Update:
 * //////////////////////////////////////////////////
 * //v0.2 Add a stop button.
 * //
 * /////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Sixi.Network.Utils;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace tracertTest
{
    public partial class Form1 : Form
    {
        private static readonly string UrlFomat = @"http://ip.taobao.com/service/getIpInfo.php?ip={0}";
        private static Dictionary<String,TaobaoJsonData> ipWhoisCache = new Dictionary<string,TaobaoJsonData>();
        String ipAddress = "";
        /// <summary>
        /// Stop traceroute
        /// </summary>
        private Boolean bIsStop = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始执行tracertRoute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            //
            button_OK.Enabled = false;
            button_stop.Enabled = true;
            textBox_Logs.AppendText("Tracert " + textBox_host.Text + " begin...\r\n");
          
            IPAddress address;
            Boolean bIsOK = false;
            bIsStop = false;
            try
            {
                // Ensure that the argument address is valid.
                if (!IPAddress.TryParse(textBox_host.Text, out address))
                {
                    //try to resolve hostname to ip address
                    try
                    {
                        IPAddress[] addrArray = Dns.GetHostAddresses(textBox_host.Text);
                        if ((null != addrArray) && (0 != addrArray.Length))
                        {
                            address = addrArray[0];
                            ipAddress = address.ToString();
                            bIsOK = true;
                            textBox_Logs.AppendText("host="+textBox_host.Text + " IP="+ipAddress+" \r\n");
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("{0} is not a valid IP address or a valid HostName.", ipAddress));
                        }
                    }
                    catch (Exception e2)
                    {
                        throw new ArgumentException(string.Format("{0} is not a valid IP address or a valid HostName.", ipAddress));
                    }
                }
                else
                {
                    ipAddress = textBox_host.Text;
                    bIsOK = true;
                }
            }
            catch (ArgumentException e1)
            {
                textBox_Logs.AppendText(e1.ToString());
                textBox_Logs.AppendText("Tracert " + textBox_host.Text + " complete.\r\n");
                textBox_Logs.AppendText("-----------------------------------------------------------------\r\n");

            }
            if (bIsOK)
            {
                Thread th = new Thread(new ThreadStart(thDoTraceRoute));
                th.IsBackground = true;
                th.Start();
            }
            else
            {
                button_OK.Enabled = true;
            }
        }

        /// <summary>
        /// traceroute Thread
        /// </summary>
        private void thDoTraceRoute()
        {
            String msg = "";
            try
            {
                if (!ipAddress.Equals(textBox_host.Text))
                {
                    msg = textBox_host.Text + "[" + ipAddress + "]";
                }
                else
                {
                    msg = textBox_host.Text;
                }

                foreach (var entry in TraceRouteHelper.Tracert(ipAddress, int.Parse(numericUpDown_MaxHops.Value.ToString()), int.Parse(numericUpDown_Timeout.Value.ToString())))
                {
                    if (bIsStop)
                    {
                        break;
                    }
                    textBox_Logs.Invoke(new MethodInvoker(delegate()
                     {
                         TaobaoJsonData tjd = new TaobaoJsonData();
                         Boolean bisOk = false;
                         if ((null != entry.Address) && (!"".Equals(entry.Address)) && (!"N/A".Equals(entry.Address)))
                         {                           
                             try
                             {
                                 long ipLong = IPHelper.Ip2Long(entry.Address);
                                 bisOk = true;
                             }
                             catch (Exception e)
                             { }
                             if (bisOk)
                             {
                                 if (!ipWhoisCache.ContainsKey(entry.Address))
                                 {
                                     tjd = getIpWhoisFromTaobao(entry.Address);
                                 }
                                 else
                                 {
                                     bisOk = ipWhoisCache.TryGetValue(entry.Address, out tjd);
                                 }                               
                             }
                         }
                         StringBuilder sb = new StringBuilder();
                         sb.Append(entry.ToString());
                         sb.Append("|");
                         if (bisOk && (tjd.code == 0))
                         {
                             //如果正常
                             sb.Append(tjd.data.country + "\t" + tjd.data.area +"\t"+tjd.data.region+ "\t" + tjd.data.city + "\t" + tjd.data.isp);
                         }
                         textBox_Logs.AppendText(sb.ToString() + "\r\n");
                     }));
                }
            }
            catch (Exception e)
            {
                textBox_Logs.Invoke(new MethodInvoker(delegate()
                {
                    textBox_Logs.AppendText(e.ToString() + "\r\n");
                }));
            }
            finally
            {
                textBox_Logs.Invoke(new MethodInvoker(delegate()
                {
                    textBox_Logs.AppendText("Tracert " + msg + " complete.\r\n");
                    textBox_Logs.AppendText("-----------------------------------------------------------------\r\n");
                }));
                button_OK.Invoke(new MethodInvoker(delegate()
                {
                    button_OK.Enabled = true;
                }));                
            }
           }

        /// <summary>
        /// 从淘宝获取IP数据
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        TaobaoJsonData getIpWhoisFromTaobao(String ip)
        {            
            string url = string.Format(UrlFomat, ip);
            string js = HttpHelper.HttpRequest(url, Encoding.UTF8);
            TaobaoJsonData tjd = new TaobaoJsonData();
            if ((js != null) && (js.Trim() != ""))
            {
                //writedata(js);
                tjd = Newtonsoft.Json.JsonConvert.DeserializeObject<TaobaoJsonData>(js);
                //将数据添加到静态缓存中
                tjd.data.ipLong = IPHelper.Ip2Long(ip);
                tjd.data.endIP = ip;
                tjd.data.endIPLong = tjd.data.ipLong;
                //增加到缓存中
                ipWhoisCache.Add(ip, tjd);
            }
            return tjd;
        }

        /// <summary>
        /// 停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_stop_Click(object sender, EventArgs e)
        {
            bIsStop = true;
            button_stop.Enabled = false;
        }
    }
}
