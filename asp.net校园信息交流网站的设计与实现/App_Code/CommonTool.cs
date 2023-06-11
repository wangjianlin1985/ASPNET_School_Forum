using System.Web; 

public class CommonTool 
{ 
/// <summary> 
/// 以流的形式，可以设置很丰富复杂的样式 
/// </summary> 
/// <param name="content">Excel中内容(Table格式)</param> 
/// <param name="filename">文件名</param> 
/// <param name="cssText">样式内容</param> 
public static void ExportToExcel(string filename, string content,string cssText) 
{ 
var res = HttpContext.Current.Response; 
content = System.String.Format("<style type='text/css'>{0}</style>{1}",cssText,content); 

res.Clear(); 
res.Buffer = true; 
res.Charset = "UTF-8"; 
res.AddHeader("Content-Disposition", "attachment; filename=" + filename); 
res.ContentEncoding = System.Text.Encoding.GetEncoding("GBK"); 
res.ContentType = "application/ms-excel;charset=GBK"; 
res.Write(content); 
res.Flush(); 
res.End(); 
} 
}
