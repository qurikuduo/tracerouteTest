using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;


namespace tracertTest
{
    /// <summary>
    /// Tracert的C#实现，参考：http://www.fluxbytes.com/csharp/tracert-implementation-in-c/
    /// </summary>
    class TraceRouteHelper
    {
        /// <summary>
        /// Traces the route which data have to travel through in order to reach an IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address of the destination.</param>
        /// <param name="maxHops">Max hops to be returned.</param>
        public static IEnumerable<TracertEntry> Tracert(string ipAddress, int maxHops, int timeout)
        {
            IPAddress address;
            
            // Ensure that the argument address is valid.
            if (!IPAddress.TryParse(ipAddress, out address))
            {
                //try to resolve hostname to ip address
                try
                {
                    IPAddress[] addrArray = Dns.GetHostAddresses(ipAddress);
                    if ((null != addrArray) && (0 != addrArray.Length))
                    {
                        address = addrArray[0];
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("{0} is not a valid IP address or a valid HostName.", ipAddress));
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(string.Format("{0} is not a valid IP address or a valid HostName.", ipAddress));
                }
            }
            else
            { 
                //throw new ArgumentException(string.Format("{0} is not a valid IP address or a valid HostName.", ipAddress));
            }
            // Max hops should be at least one or else there won't be any data to return.
            if (maxHops < 1)
                throw new ArgumentException("Max hops can't be lower than 1.");

            // Ensure that the timeout is not set to 0 or a negative number.
            if (timeout < 1)
                throw new ArgumentException("Timeout value must be higher than 0.");


            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            Stopwatch pingReplyTime = new Stopwatch();
            PingReply reply;

            do
            {
                pingReplyTime.Start();
                reply = ping.Send(address, timeout, new byte[] { 0 }, pingOptions);
                pingReplyTime.Stop();

                string hostname = string.Empty;
                if (reply.Address != null)
                {
                    try
                    {
                        hostname = Dns.GetHostByAddress(reply.Address).HostName;    // Retrieve the hostname for the replied address.
                    }
                    catch (SocketException) { /* No host available for that address. */ }
                }

                // Return out TracertEntry object with all the information about the hop.
                yield return new TracertEntry()
                {
                    HopID = pingOptions.Ttl,
                    Address = reply.Address == null ? "N/A" : reply.Address.ToString(),
                    Hostname = hostname,
                    ReplyTime = pingReplyTime.ElapsedMilliseconds,
                    ReplyStatus = reply.Status
                };

                pingOptions.Ttl++;
                pingReplyTime.Reset();
            }
            while (reply.Status != IPStatus.Success && pingOptions.Ttl <= maxHops);
        }
    }
}
