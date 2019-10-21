using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
namespace Crawlbilibili
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filepath = null;
        string link = null;
        DataTable datatable = new DataTable();
        #region
        private string [] GetvedioID(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("输入链接为空", "提示");
                return null;
            }
            else
            {
                string [] temp = url .Split (',');
                return temp;
            }
            return null;  
        }

        private void crawlingImg_Click(object sender, EventArgs e)
        {
            string[] IDlist;
            IDlist = GetvedioID(this .urltxt .Text );
            if (IDlist == null)
            {
                return;
            }
             //循环下载图片
            for (int i = 0; i < IDlist.Length; i++)
            {
                CatchImg(IDlist[i]);
                BindData();
            }
        }

        private void CatchImg(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("链接错误，或者为空");
                    return;
                }
                //获取服务器响应
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                int ins = 0;
                //防止某些服务器反爬虫，进而模拟浏览器登录
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; QQWubi 133; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; CIBA; InfoPath.2)";
                request.Method = "Get";
                //设置响应时间
                request .Timeout =5000;
                request.Headers.Add("Accept-Encoding","gzip,deflate");
                //获取服务器的响应
                string htmltxt;
                HttpWebResponse response =(HttpWebResponse) request.GetResponse();
                //判断网页是否进行Gzip压缩
                if (response.ContentEncoding.ToLower() == "gzip")
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (var zipstream = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress))
                        {
                            //读取网页
                            StreamReader reader = new StreamReader(zipstream, Encoding.UTF8);
                            htmltxt = reader.ReadToEnd();
                        }
                    }

                } 
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        htmltxt = reader.ReadToEnd();
                    }
                }
                //
                Regex regex = new Regex("<meta data-vue-meta=\"true\" itemprop=\"image\"(?<Link>.*?(?=\\>))", RegexOptions.Singleline);
                link = regex.Match(htmltxt).Groups["Link"].Value;
                int index = link.IndexOf("=");
                link = link.Substring(index + 1);//图片链接地址
                regex = new Regex("\"(?<link>\\S+)\"", RegexOptions.Singleline);
                link = regex.Match(link).Groups["link"].Value;
                //下载ins图片
                if (string.IsNullOrEmpty(link))
                {
                    regex = new Regex(" <meta property=\"og:image\" content=\"(?<Link>\\S+)\" />", RegexOptions.Singleline );
                    link = regex.Match(htmltxt).Groups["Link"].Value;
                    ins = 1;
                }
                //获取图片
                //重新与网站取得链接
                WebRequest webrequest = WebRequest.Create(link);
                WebResponse webresponse = webrequest.GetResponse();
                //获取服务器返回的网络文件流
                Stream netstream = webresponse.GetResponseStream();
                //将图片存入文件夹
                string path;
                if (ins == 1)
                {
                    path = @"E:\ins";
                    ins = 0;
                }
                else
                { 
                   path = @"E:\Crawlimage";
                }
                
                if (!System.IO.Directory.Exists(path))
                {   //如果文件不存在则创建新的文件夹
                    System.IO.Directory.CreateDirectory(path);
                }
                //给文件命名,出现一般性GDI+错误的原因是文件名出现了非法的字符串
                string filename = DateTime.Now.ToString("yyyymmmhhmm") + ".jpg";
                Image.FromStream(netstream).Save(path + "\\" + filename);
                filepath = path + "\\" + filename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindData()
        {
             
            if (!string.IsNullOrEmpty(link))
            { 
                int index=link .LastIndexOf ("//");
                link = link.Substring(index + 1);
                if (System.IO.File.Exists(filepath))
                {
                    DataRow row = datatable.NewRow();
                    row[0] = link;
                    row[1] = "下载成功";
                    datatable.Rows.Add(row);
                }
                else
                {
                    DataRow row = datatable.NewRow();
                    row[0] = link;
                    row[1] = "下载失败";
                    datatable.Rows.Add(row);   
                } 
            }
            this.IDlistGrid.DataSource = datatable;
            for (int i = 0; i < this.IDlistGrid.ColumnCount; i++)
            {
                this.IDlistGrid.Columns[i].Width = this.IDlistGrid.Size.Width / this.IDlistGrid.Columns.Count;
            }
            this.IDlistGrid.ReadOnly = true;
            this.IDlistGrid.AllowUserToAddRows = false;
            this.IDlistGrid.ClearSelection();
            this.IDlistGrid.Refresh();
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            datatable.Columns.Add("图片名");
            datatable.Columns.Add("状态");
            BindData();
        }
    }
}
