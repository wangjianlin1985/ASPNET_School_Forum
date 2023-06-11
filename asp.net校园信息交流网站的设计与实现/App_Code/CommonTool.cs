using System.Web; 

public class CommonTool 
{ 
/// <summary> 
/// ��������ʽ���������úܷḻ���ӵ���ʽ 
/// </summary> 
/// <param name="content">Excel������(Table��ʽ)</param> 
/// <param name="filename">�ļ���</param> 
/// <param name="cssText">��ʽ����</param> 
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
