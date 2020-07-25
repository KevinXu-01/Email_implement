using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;
namespace E_mail_implements
{

    class mail
    {
        public String sender;//发送方
        public String date;//日期
        public String subject;//主题
        public String content;//正文
        public bool hasFile;//是否有附件（还没写）
        public List<Mail_file> files = new List<Mail_file>();//附件列表
        public mail(String Envelop)
        {
            this.setDate(Envelop);
            this.setSender(Envelop);
            this.setSubject(Envelop);
            this.setTypeAndContent(Envelop);
        }
        public void setSender(String Envelop)//匹配获得发送方
        {
            string reg = "(?<=(X-Sender: ))[.\\s\\S]*?(?=(\n))";

            this.sender = GetSingle(Envelop, reg);
        }
        public void setDate(String Envelop)//匹配获得日期
        {
            string reg = "(?<=(Date: ))[.\\s\\S]*?(?=(\n))";
            string[] a = Getunit(Envelop, reg);
            this.date = a[0];
        }
        public void setSubject(String Envelop)//获得主题
        {
            string reg = "(?<=(Subject: ))[.\\s\\S]*?(?=(\n))";
            string[] a = Getunit(Envelop, reg);
            this.subject = a[0];
            string temp = GetSingle(a[0], "(?<=(UTF-8\\?B\\?))[.\\s\\S]*?(?=(\\?=))");
            if (temp!=null)
            {
                this.subject = ConvertFromBaseToUtf(temp);
            }
            string temp2 = GetSingle(a[0], "(?<=(gb18030\\?B\\?))[.\\s\\S]*?(?=(\\?=))");
            if (temp2 != null)
            {
                this.subject = ConvertFromBaseToGB(temp2);
            }
            string temp3 = GetSingle(a[0], "(?<=(GBK\\?B\\?))[.\\s\\S]*?(?=(\\?=))");
            if (temp3 != null)
            {
                this.subject = ConvertFromBaseToGB(temp3);
            }
        }

        public String ConvertFromBaseToUtf(String s)
        {
            string result = null;
            byte[] temp = Convert.FromBase64String(s);
            result=Encoding.GetEncoding("utf-8").GetString(temp);
            return result;
        }
        public string ConvertFromBaseToGB(string s)
        {
            string result = null;
            byte[] temp = Convert.FromBase64String(s);
            result = Encoding.GetEncoding("gb18030").GetString(temp);
            return result;

        }
        public void setTypeAndContent(String Envelop)//设定是否含有附件
        {
            string reg = "multipart";
            bool isMatch = Regex.IsMatch(Envelop, reg);
            this.hasFile = isMatch;
            if (hasFile)//如果有附件
            {
                string r = "(?<=(--=))[.\\s\\S]*?(?=(--=))";
                string[] a = Getunit(Envelop, r);
                for (int i = 0; i < a.Count(); i++)
                {
                    string text = "text/plain";
                    string file = "filename";

                    if (Regex.IsMatch(a[i], text) && !Regex.IsMatch(a[i], file))
                    {
                        //提取文本，该文本为正文
                        string con = "(?<=(\r\n\r\n))[.\\s\\S]*?(?=(\r\n))";
                        string[] b = Getunit(a[i], con);
                        this.content =b[0];//将正文的内容放进去
                        if (Regex.IsMatch(a[i], "Content-Transfer-Encoding: base64"))
                        {
                            if (Regex.IsMatch(a[i], "gb") || Regex.IsMatch(a[i], "GB"))
                            {
                                this.content = ConvertFromBaseToGB(b[0]);
                            }
                            else if (Regex.IsMatch(a[i], "UTF"))
                            {
                                this.content = ConvertFromBaseToUtf(b[0]);
                            }
                            
                        }
                        
                    }
                    
                    else if (Regex.IsMatch(a[i], file))
                    {
                       //附件提取
                        string filenameReg = "(?<=(filename=\"))[.\\s\\S]*?(?=(\"))";
                        string filename = GetSingle(a[i], filenameReg);
                        string codeReg = "(?<=(\r\n\r\n))[.\\s\\S]*?(?=(\r\n--))";
                        string code = GetSingle(a[i], codeReg);
                        string TypeReg = "(?<=(Content-Type: ))[.\\s\\S]*?(?=(;))";
                        string type = GetSingle(a[i], TypeReg);
                        Mail_file file1 = new Mail_file(filename, code, type);
                        this.files.Add(file1);
                       
                    }

                }
            }
            else//否则设置正文（有附件的获得正文方式和没有附件不太一样）
            {
                string r = "(?<=(\r\n\r\n\r\n))[.\\s\\S]*?(?=(\r\n\r\n))";
                string[] a = Getunit(Envelop, r);
                this.content = a[0];
                if (Regex.IsMatch(Envelop, "Content-Transfer-Encoding: base64"))
                {
                    if (Regex.IsMatch(Envelop, "gb") || Regex.IsMatch(Envelop, "GB"))
                    {
                        this.content = ConvertFromBaseToGB(a[0]);
                    }
                    else if (Regex.IsMatch(Envelop, "UTF"))
                    {
                        this.content = ConvertFromBaseToUtf(a[0]);
                    }

                }
            }
        }
        private string[] Getunit(string value, string regx)//获得正则匹配的字符
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            bool isMatch = Regex.IsMatch(value, regx);
            if (!isMatch)
            {

                return null;
            }
            MatchCollection matchCol = Regex.Matches(value, regx);
            string[] result = new string[matchCol.Count];
            if (matchCol.Count > 0)
            {
                for (int i = 0; i < matchCol.Count; i++)
                {
                    result[i] = matchCol[i].Value;
                }
            }
            return result;
        }
        private string GetSingle(string value, string regx)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            bool isMatch = Regex.IsMatch(value, regx);
            if (!isMatch)
            {
                return null;
            }
            MatchCollection matchCol = Regex.Matches(value, regx);

            string result = matchCol[0].Value;

            return result;
        }


    }
}
