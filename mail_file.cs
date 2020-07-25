using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_mail_implements
{
    public class Mail_file
    {
        public string Name;
        public string BaseCode;
        public string Type;
        public Mail_file(string Name, string BaseCode, string Type)
        {
            this.Name = Name;
            this.BaseCode = BaseCode;
            this.Type = Type;
            string temp = GetSingle(this.Name, "(?<=(UTF-8\\?B\\?))[.\\s\\S]*?(?=(\\?=))");
            if (temp != null)
            {
                this.Name = ConvertFromBaseToUtf(temp);
            }
            string temp2 = GetSingle(this.Name, "(?<=(gb18030\\?B\\?))[.\\s\\S]*?(?=(\\?=))");
            if (temp2 != null)
            {
                this.Name = ConvertFromBaseToGB(temp2);
            }
        }
        public String ConvertFromBaseToUtf(String s)
        {
            string result = null;
            byte[] temp = Convert.FromBase64String(s);
            result = Encoding.GetEncoding("utf-8").GetString(temp);
            return result;
        }
        public string ConvertFromBaseToGB(string s)
        {
            string result = null;
            byte[] temp = Convert.FromBase64String(s);
            result = Encoding.GetEncoding("gb18030").GetString(temp);
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
