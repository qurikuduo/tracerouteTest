using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Sixi.Network.Utils
{
    public class IPHelper
    {
        /// <summary>
        /// 用于特殊用途的IP地址的哈希表，Key为起始地址，Value为结束地址
        /// </summary>
        private static SortedDictionary<long, long> specialUseAddressDic = new SortedDictionary<long, long>();

        /// <summary>
        /// 静态私有构造函数，用于初始化特殊用途的IP地址的哈希表
        /// </summary>
        static IPHelper()
        {
            //0.0.0.0/8	本网络（仅作为源地址时合法）	RFC 5735
            //0.0.0.0-0.255.255.255
            //0-16777215
            specialUseAddressDic.Add(0L, 16777215L);

            //10.0.0.0/8	专用网络	RFC 1918
            //10.0.0.0-10.255.255.255
            //167772160-184549375
            specialUseAddressDic.Add(167772160L, 184549375L);

            //127.0.0.0/8	环回	RFC 5735
            //127.0.0.0-127.255.255.255
            //2130706432-2147483647
            specialUseAddressDic.Add(2130706432L, 2147483647L);

            //169.254.0.0/16	链路本地	RFC 3927
            //169.254.0.0-169.254.255.255
            //2851995648-2852061183
            specialUseAddressDic.Add(2851995648L, 2852061183L);

            //172.16.0.0/12	专用网络	RFC 1918
            //172.16.0.0-172.31.255.255
            //2886729728-2887778303
            specialUseAddressDic.Add(2886729728L, 2887778303L);

            //192.0.0.0/24	保留（IANA）	RFC 5735
            //192.0.0.0-192.0.0.255
            //3221225472-3221225727
            specialUseAddressDic.Add(3221225472L, 3221225727L);

            //192.0.2.0/24	TEST-NET-1，文档和示例	RFC 5735
            //192.0.2.0-192.0.2.255
            //3221225984-3221226239
            specialUseAddressDic.Add(3221225984L, 3221226239L);

            //192.88.99.0/24	6to4中继	RFC 3068
            //192.88.99.0-192.88.99.255
            //3227017984-3227018239
            specialUseAddressDic.Add(3227017984L, 3227018239L);

            //192.168.0.0/16	专用网络	RFC 1918
            //192.168.0.0-192.168.255.255
            //3232235520-3232301055
            specialUseAddressDic.Add(3232235520L, 3232301055L);

            //198.18.0.0/15	网络基准测试	RFC 2544
            //198.18.0.0-198.19.255.255
            //3323068416-3323199487
            specialUseAddressDic.Add(3323068416L, 3323199487L);

            //198.51.100.0/24	TEST-NET-2，文档和示例	RFC 5737
            //198.51.100.0-198.51.100.255
            //3325256704-3325256959
            specialUseAddressDic.Add(3325256704L, 3325256959L);

            //203.0.113.0/24	TEST-NET-3，文档和示例	RFC 5737
            //203.0.113.0-203.0.113.255
            //3405803776-3405804031
            specialUseAddressDic.Add(3405803776L, 3405804031L);


            //把下面两种情况合成为一种
            specialUseAddressDic.Add(3758096384L, 4294967295L);

            //224.0.0.0/4	多播（之前的D类网络）	RFC 3171
            //224.0.0.0-239.255.255.255
            //3758096384-4026531839
            //speciaLUseAddressHashTabLe.Add(3758096384L, 4026531839L);

            //240.0.0.0/4	保留（之前的E类网络）	RFC 1700
            //240.0.0.0-255.255.255.255
            //4026531840-4294967295
            //speciaLUseAddressHashTabLe.Add(4026531840L, 4294967295L);

            //255.255.255.255	广播	RFC 919
        }

        /// <summary>
        /// ip转成long
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static long Ip2Long(string ip)
        {
            byte[] bytes = Ip2Bytes(ip);
            return Bytes2Long(bytes);
        }
        /// <summary>
        /// long转成ip
        /// </summary>
        /// <param name="ipLong"></param>
        /// <returns></returns>
        public static string Long2Ip(long ipLong)
        {
            byte[] bytes = Long2Bytes(ipLong);
            return Bytes2Ip(bytes);
        }
        /// <summary>
        /// long转成byte[]
        /// </summary>
        /// <param name="ipvalue"></param>
        /// <returns></returns>
        public static byte[] Long2Bytes(long ipvalue)
        {
            byte[] b = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                b[3 - i] = (byte)(ipvalue >> 8 * i & 255);
            }
            return b;
        }
        /// <summary>
        /// byte[]转成long
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public static long Bytes2Long(byte[] bt)
        {
            int x = 3;
            long o = 0;
            foreach (byte f in bt)
            {
                o += (long)f << 8 * x--;
            }
            return o;
        }
        /// <summary>
        /// ip转成byte[]
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static byte[] Ip2Bytes(string ip)
        {
            string[] sp = ip.Split('.');
            return new byte[] { Convert.ToByte(sp[0]), Convert.ToByte(sp[1]), Convert.ToByte(sp[2]), Convert.ToByte(sp[3]) };
        }
        /// <summary>
        /// byte[]转成ip
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Bytes2Ip(byte[] bytes)
        {
            return string.Format("{0}.{1}.{2}.{3}"
                                   , bytes[0]
                                   , bytes[1]
                                   , bytes[2]
                                   , bytes[3]);
        }

        /// <summary>
        /// 判断某个IP是否是特殊用途的IP
        /// </summary>
        /// <param name="ip">需要进行判断的IP</param>
        /// <returns>返回true是特殊用途的IP，否则返回false</returns>
        public static bool IsSpecialUseAddress(String ip)
        {
            return IsSpecialUseAddress(Ip2Long(ip));
        }

        /// <summary>
        /// 判断某个IP是否是特殊用途的IP
        /// </summary>
        /// <param name="ip">需要进行判断的IP</param>
        /// <returns>返回true是特殊用途的IP，否则返回false</returns>
        public static bool IsSpecialUseAddress(long ip)
        {

            foreach (KeyValuePair<long, long> item in specialUseAddressDic)
            {
                if ((item.Key <= ip) && (item.Value >= ip))
                {
                    return true;
                }
                //加快查询速度
                ////如果ip比本次循环的最大值都小，并且之前的循环都没有判断出它是特殊用途的ip，则可以认为这个IP是正常的IP
                ////但是这跟dic中元素的排序有关，请不要对元素进行反向排序（默认是正向排序的）
                //if (ip < item.Value)
                //{
                //    break;
                //}
            }
            return false;
        }
    }
}
