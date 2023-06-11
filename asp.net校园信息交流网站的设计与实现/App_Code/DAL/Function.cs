using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;

namespace DAL
{
    public class Function
    {

        /*根据当前系统时间生成一个文件名*/
        public static string MakeFileName(string exeFileString)
        {
            System.DateTime now = System.DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            string yearString = year.ToString();
            string monthString = month < 10 ? ("0" + month) : month.ToString();
            string dayString = day < 10 ? ("0" + day) : day.ToString();
            string hourString = hour < 10 ? ("0" + hour) : hour.ToString();
            string minuteString = minute < 10 ? ("0" + minute) : minute.ToString();
            string secondString = second < 10 ? ("0" + second) : second.ToString();

            /*根据当前时间的年月日时分秒生成文件名*/
            string fileName = yearString + monthString + dayString + hourString + minuteString + secondString + exeFileString;
            return fileName;
        }



        //清楚文本中的html标签
        public static string RemoveHTMLLabel(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        ///网站计数器
        public static bool Counter(string tablename, string CNID)
        {
            string sql = "update TextNews set VisitedCount=VisitedCount+1 where TNID =" + Convert.ToInt32(CNID) + "";
            if (tablename == "PicNews")
                sql = "update PicNews set VisitedCount =VisitedCount+1 where PNID = " + Convert.ToInt32(CNID) + " ";
            return (DBHelp.ExecuteNonQuery(sql, null) > 0) ? true : false;
        }



        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public static string CheckStr(object strValue, int Len)
        {
            return (strValue.ToString().Length > Len) ? strValue.ToString().Substring(0, Len) + ".." : strValue.ToString();
        }
        /// <summary>
        /// 将指定路径中的文件内容读出来 以字符串形式返回
        /// </summary>
        /// <param name="filenam">文件相对路径</param>
        /// <returns></returns>
        public static string ReadFiles(string filePath)
        {
            if (File.Exists(filePath))
            {
                //读取文本　
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
            else
                return "";
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileUp">上传控件</param>
        /// <param name="fileExtension">上传文件类型</param>
        public static int UpFile(System.Web.UI.Page page, System.Web.UI.WebControls.FileUpload fileUp, string fileExtension, string strNewName)
        {
            //上传结果 0未知 1成功  -1文件格式有误 -2文件太大
            int strValue = 0;
            string fileName = fileUp.FileName;
            FileInfo fileinfo = new FileInfo(fileName);
            switch (fileExtension)
            {
                case "img":
                    if (fileinfo.Extension.ToLower() == ".gif" || fileinfo.Extension.ToLower() == ".jpg" || fileinfo.Extension.ToLower() == ".png" || fileinfo.Extension.ToLower() == ".bmp")
                    {
                        if (fileUp.PostedFile.ContentLength <= Convert.ToInt64(Common.GetMes.GetConfigAppValue("ImageSize")))
                        {
                            UpLoadFile(page, fileUp, Common.GetMes.GetConfigAppValue("AdImgURL"), strNewName);
                            strValue = 1;
                        }
                        else
                        {
                            strValue = -2; //文件太大 !
                        }
                    }
                    else
                    {
                        strValue = -1; //格式有误！
                    }
                    break;
                default:
                    break;
            }
            return strValue;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="page">页面对象</param>
        /// <param name="fileload">上传控件</param>
        /// <param name="strPath">路径</param>
        public static void UpLoadFile(System.Web.UI.Page page, System.Web.UI.WebControls.FileUpload fileload, string strPath, string strNewName)
        {
            string ServerPath = page.Server.MapPath(strPath);
            if (!Directory.Exists(ServerPath))
            {
                //若文件目录不存在 则创建
                Directory.CreateDirectory(ServerPath);
            }
            ServerPath += strNewName;
            try
            {
                fileload.SaveAs(ServerPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检测用户状态
        /// </summary>
        public static void CheckState()
        {

            if (string.IsNullOrEmpty(Common.GetMes.GetSession("Customername")))
            {
                if (!string.IsNullOrEmpty(Common.GetMes.GetCookies("Customername")))
                {
                    Common.SetMes.SetSession("Customername", Common.EncryptString.joecrown(Common.GetMes.GetCookies("UserID"), 6));
                }
                else
                {
                    Common.CheckMes.CheckState("Customername", "M_UserLogin.aspx", "请登录后再进行操作......");
                }
            }
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>　　
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, string imageType)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）　　　　　　　　
                    break;
                case "W"://指定宽，高按比例　　　　　　　　　　
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）　　　　　　　　
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
              new Rectangle(x, y, ow, oh),
              GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                switch (imageType.ToLower())
                {
                    case "gif":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "jpg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "bmp":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "png":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 自定义加密密码
        /// </summary>
        /// <param name="strPass"></param>
        /// <returns></returns>
        public static string PassEnCode(string strPass)
        {
            return Common.EncryptString.crownjoe(Common.EncryptString.encryptMD5(strPass).Substring(0, 15), false);
        }
        #region##得到真实IP以及所在地详细信息
        /// <summary>    
        /// 得到真实IP以及所在地详细信息（Porschev）    
        /// </summary>    
        /// <returns></returns>    
        public static string GetIpDetails()
        {
            string url = "http://www.ip138.com/ips8.asp";   //设置获取IP地址和国家源码的网址        
            string regStr = "(?<=<td\\s*align=\\\"center\\\">)[^<]*?(?=<br/><br/></td>)";
            string ipRegStr = "((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)";    //IP正则                
            string ip = string.Empty;   //IP地址        
            string country = string.Empty;  //国家        
            string adr = string.Empty;   //省市        
            string html = GetHtml(url);       //得到网页源码        
            Regex reg = new Regex(regStr, RegexOptions.None);
            Match ma = reg.Match(html); html = ma.Value;
            Regex ipReg = new Regex(ipRegStr, RegexOptions.None);
            ma = ipReg.Match(html);
            ip = ma.Value;     //得到IP        
            int index = html.LastIndexOf("：") + 1;
            country = html.Substring(index);                   //得到国家        
            adr = GetAdrByIp(ip);
            return "IP：" + ip + "  国家：" + country;
        }
        #endregion

        #region##通过IP得到IP所在地省市
        /// <summary>    
        /// 通过IP得到IP所在地省市（Porschev）    
        /// </summary>    
        /// <param name="ip"></param>    
        /// <returns></returns>    
        public static string GetAdrByIp(string ip)
        {
            string url = "http://www.cz88.net/ip/?ip=" + ip;
            string regStr = "(?<=<span\\s*id=\\\"cz_addr\\\">).*?(?=</span>)";
            string html = GetHtml(url);       //得到网页源码        
            Regex reg = new Regex(regStr, RegexOptions.None);
            Match ma = reg.Match(html);
            html = ma.Value;
            string[] arr = html.Split(' ');
            return arr[0];
        }
        #endregion

        #region##获取HTML源码信息
        /// <summary>    
        /// 获取HTML源码信息(Porschev)    
        /// </summary>    
        /// <param name="url">获取地址</param>    
        /// <returns>HTML源码</returns>    
        public static string GetHtml(string url)
        {
            Uri uri = new Uri(url);
            WebRequest wr = WebRequest.Create(uri);
            Stream s = wr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            return sr.ReadToEnd();
        }
        #endregion

    }
}
