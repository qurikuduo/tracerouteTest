using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using Sixi.Network.Utils;

/// <summary>
/// 淘宝数据
/// </summary>
public partial class TaobaoIPdata
{
    private long _ipLong;
    /// <summary>
    /// IP 长整形
    /// </summary>
    public long ipLong
    {
        get { return _ipLong; }
        set { _ipLong = value; }
    }

    private string _ip;
    /// <summary>
    /// IP地址
    /// </summary>
    public string ip
    {
        get { return _ip; }
        set { _ip = value; }
    }

    private string _country;
    /// <summary>
    /// 国家
    /// </summary>
    public string country
    {
        get { return _country; }
        set { _country = value; }
    }

    private string _country_id;
    /// <summary>
    /// 国家编号
    /// </summary>
    public string country_id
    {
        get { return _country_id; }
        set { _country_id = value; }
    }

    private string _area;
    /// <summary>
    /// 地区
    /// </summary>
    public string area
    {
        get { return _area; }
        set { _area = value; }
    }

    private string _area_id;
    /// <summary>
    /// 地区编号
    /// </summary>
    public string area_id
    {
        get { return _area_id; }
        set { _area_id = value; }
    }

    private string _region;
    /// <summary>
    /// 区域
    /// </summary>
    public string region
    {
        get { return _region; }
        set { _region = value; }
    }

    private string _region_id;
    /// <summary>
    /// 区域编号
    /// </summary>
    public string region_id
    {
        get { return _region_id; }
        set { _region_id = value; }
    }

    private string _city;
    /// <summary>
    ///城市
    /// </summary>
    public string city
    {
        get { return _city; }
        set { _city = value; }
    }

    private string _city_id;
    /// <summary>
    /// 城市编号
    /// </summary>
    public string city_id
    {
        get { return _city_id; }
        set { _city_id = value; }
    }

    private string _county;
    /// <summary>
    /// 县
    /// </summary>
    public string county
    {
        get { return _county; }
        set { _county = value; }
    }

    private string _county_id;
    /// <summary>
    /// 县编号
    /// </summary>
    public string county_id
    {
        get { return _county_id; }
        set { _county_id = value; }
    }

    private string _isp;
    /// <summary>
    /// 供应商
    /// </summary>
    public string isp
    {
        get { return _isp; }
        set { _isp = value; }
    }

    private string _isp_id;
    /// <summary>
    /// 供应商ID
    /// </summary>
    public string isp_id
    {
        get { return _isp_id; }
        set { _isp_id = value; }
    }

    private String _endIP;
    /// <summary>
    /// 结束IP
    /// </summary>
    public String endIP
    {
        get { return _endIP; }
        set { _endIP = value; }
    }

    private long _endIPLong;
    /// <summary>
    /// 结束IP的Long形式
    /// </summary>
    public long endIPLong
    {
        get { return _endIPLong; }
        set { _endIPLong = value; }
    }

    /*
     //存放所有淘宝IP数据的排序字典
     public static SortedDictionary<long, TaobaoIPdata> allTaobaoIPdata = new SortedDictionary<long, TaobaoIPdata>();
     private static KeyValuePair<long, TaobaoIPdata>[] allTaobaoDataKVArray = new KeyValuePair<long, TaobaoIPdata>[0];
    static TaobaoIPdata()
    {       
        copyDic2Array();
    }
    /// <summary>
    /// 将数据从排序的字典拷贝到数组里
    /// </summary>
    private static void copyDic2Array()
    {
        allTaobaoDataKVArray = new KeyValuePair<long, TaobaoIPdata>[allTaobaoIPdata.Count];
        allTaobaoIPdata.CopyTo(allTaobaoDataKVArray, 0);
    }
    /// <summary>
    /// 从文件中加载IP结果数据的json格式
    /// </summary>
    /// <param name="filePath">保存json格式数据的文件地址</param>
    private static void LoadIPJsonDataFromFile(String filePath)
    {
        Boolean bIsOK = true;
        if (!File.Exists(filePath))
        {
            //如果文件不存在，则给出提示，退出
            bIsOK = false;
        }
        //如果存在文件，
        using (StreamReader sr = new StreamReader(filePath, true))
        {
            String line = null;
            while (sr.Peek() > -1)
            {
                //读取一行
                line = sr.ReadLine().Trim();
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                try
                {
                    TaobaoJsonData tjd = new TaobaoJsonData();
                    tjd = Newtonsoft.Json.JsonConvert.DeserializeObject<TaobaoJsonData>(line.Trim());
                    //将数据添加到静态缓存中
                    if ((tjd != null) && (tjd.data != null))
                    {
                        allTaobaoIPdata.Add(tjd.data.ipLong, tjd.data);
                    }                    
                }
                catch (Exception e)
                {
                    //do nothing
                }
            }
        }
    }
     /// <summary>
    /// 从文件中加载IP结果数据的文本格式
    /// </summary>
    /// <param name="filePath">保存文本格式数据的文件地址</param>
    private static void LoadIPTextDataFromFile(String filePath)
    {
        Boolean bIsOK = true;
        if (!File.Exists(filePath))
        {
            //如果文件不存在，则给出提示，退出
            bIsOK = false;
        }
            //如果存在文件，
        using (StreamReader sr = new StreamReader(filePath, true))
        {
            String line=null;
                
            TaobaoIPdata data;
            long count = 0;
            while (sr.Peek()>-1)
            {
                count++;
                //读取一行
                line = sr.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                String[] lineArr = line.Split(new char[]{'\t'},StringSplitOptions.None);
                if ((lineArr != null) && (lineArr.Length == 16))
                {
                    data = new TaobaoIPdata();
                    data.ipLong = long.Parse(lineArr[0]);
                    data.ip = lineArr[1];
                    data.endIPLong = long.Parse(lineArr[2]);
                    data.endIP = lineArr[3];
                    data.country = lineArr[4];
                    data.country_id = lineArr[5];
                    data.area = lineArr[6];
                    data.area_id = lineArr[7];
                    data.region = lineArr[8];
                    data.region_id = lineArr[9];
                    data.city = lineArr[10];
                    data.city_id = lineArr[11];
                    data.county = lineArr[12];
                    data.county_id = lineArr[13];
                    data.isp = lineArr[14];
                    data.isp_id = lineArr[15];
                    allTaobaoIPdata.Add(data.ipLong, data);
                }
                else
                {
                    Console.WriteLine("IP:"+line);
                }

            }
        }           
    }
    
      /// <summary>
    /// 根据IP查询该IP的信息
    /// </summary>
    /// <param name="ip">ip的long型</param>
    /// <returns>返回查询到的结果</returns>
    public static TaobaoIPdata query(String ip)
    {
        if (String.IsNullOrEmpty(ip))
        {
            return null;
        }
        return query(IPHelper.Ip2Long(ip));
    }
    /// <summary>
    /// 根据IP查询该IP的信息
    /// </summary>
    /// <param name="ip">ip的long型</param>
    /// <returns>返回查询到的结果</returns>
    public static TaobaoIPdata query(long ip)
    {
        TaobaoIPdata data=null;
        bool bIsOK = false;
        if (allTaobaoIPdata.ContainsKey(ip))
        {
            data = new TaobaoIPdata();
            if (!allTaobaoIPdata.TryGetValue(ip, out data))
            {
                bIsOK = false;
            }
            else
            {
                bIsOK = true;
            }
        }
        else
        {
            //改用二分查找法，优化性能
          
            data = query(allTaobaoDataKVArray, ip, 0, allTaobaoDataKVArray.Length - 1);
            ////如果key不存在或者未获取到，则遍历获取
            //foreach (KeyValuePair<long,TaobaoIPdata> kv in allTaobaoIPdata)
            //{
            //    if((kv.Key<=ip)&&(kv.Value.endIPLong>=ip))
            //    {
            //        //如果正好处在当前区域，则取出
            //        data = kv.Value;
            //        bIsOK = true;
            //        break;
            //    }
            //    else if (kv.Key > ip)
            //    {
            //        //如果当前key已经大于要查询的IP，则说明无此记录，可以停止查询
            //        bIsOK = false;
            //        break;
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
        }
        //if(!bIsOK)
        //{
        //    ////如果key不存在或者未获取到，则遍历获取
        //    //foreach (KeyValuePair<long, TaobaoIPdata> item in allTaobaoIPdata)
        //    //{
        //    //    if ((item.Key <= ip) && (item.Value.endIPLong >= ip))
        //    //    {
        //    //        data = item.Value;   
        //    //    }
        //    //    //加快查询速度
        //    //    ////如果ip比本次循环的最大值都小，并且之前的循环都没有判断出它是特殊用途的ip，则可以认为这个IP是正常的IP
        //    //    ////但是这跟dic中元素的排序有关，请不要对元素进行反向排序（默认是正向排序的）
        //    //    if (ip < item.Value.endIPLong)
        //    //    {
        //    //        break;
        //    //    }
        //    //}
          
        //}
        return data;
    }
   /// <summary>
    /// 二分查找法
   /// </summary>
   /// <param name="dic">要查找的集合</param>
   /// <param name="ip">要查找的IP</param>
   /// <param name="begin">开始索引</param>
   /// <param name="end">结束索引</param>
   /// <returns>查询结果，如果为null则表示未查到，如果非null，表示查询到的结果</returns>
    private static TaobaoIPdata query(KeyValuePair<long, TaobaoIPdata>[] dic, long ip, long begin, long end)
    {
        TaobaoIPdata data = null;
          if (begin>end)
            {
                return data;
            }
          long mid = (begin + end) / 2;
          if ((dic[mid].Key < ip) && (dic[mid].Value.endIPLong >= ip))
          {
              //找到了
              data = dic[mid].Value;
              return data;
          }

          if (dic[mid].Key > ip)
          {
              //查前半部分
              return query(dic, ip, begin, mid - 1);
          }
          else
          {
              //查后半部分
              return query(dic, ip, mid + 1, end);
          }
    }
    /// <summary>
    /// 往缓存里添加对象
    /// </summary>
    /// <param name="data">要添加的对象</param>
    public static void add(TaobaoIPdata data)
    {
        if((data!=null)&&(data.ip!=null))
        {
            if (!allTaobaoIPdata.ContainsKey(data.ipLong))
            { 
                allTaobaoIPdata.Add(data.ipLong, data);
                copyDic2Array();
            }
        }
    }

    
    /// <summary>
    /// 返回当前对象的json格式的字符串
    /// </summary>
    /// <returns>返回的是当前对象的json格式的字符串</returns>
    public override string ToString()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(this);        
    }
    */
}
/// <summary>
/// 淘宝api 返回的json数据
/// </summary>
public partial class TaobaoJsonData
{
    public int code { get; set; }
    public TaobaoIPdata data { get; set; }
}