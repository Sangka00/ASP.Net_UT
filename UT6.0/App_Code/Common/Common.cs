using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Sockets;
using log4net;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;

/// <summary>
/// Common의 요약 설명입니다.
/// </summary>
/// 
namespace GDSCommon
{
    public class Common
    {
        public Common()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }
        public static string checkTimestamp(string sREQTime)
        {
            string sResult = "N";

            try
            {
                double nREQTime = Convert.ToDouble(sREQTime.Replace("-", "").Replace(":", "").Replace(" ", ""));

                double nRESTime = Convert.ToDouble(DateTime.UtcNow.ToString("yyyyMMddHHmmss"));
                double dd = Math.Abs(nRESTime - nREQTime);
                if (Math.Abs(nRESTime - nREQTime) < 10000)
                {
                    sResult = "Y";
                }
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            return sResult;
        }
        public static string GetValue(XElement pnode, string name)
        {
            string result = string.Empty;
            XElement node = pnode.Element(name);
            if (node != null) result = node.Value;
            return result;
        }
        public static string GetAttribute(XElement node, string name)
        {

            string result = string.Empty;
            XAttribute attr = node.Attribute(name);
            if (attr != null) result = attr.Value;
            return result;
        }
        //xml attribute가져오기
        public static string getAttributeValue(XmlNode xmlNode, string sAttribute)
        {
            string sResult = string.Empty;

            try
            {
                sResult = xmlNode.Attributes[sAttribute].Value;
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            return sResult;
        }

        public static string getStrVal(object objValue)
        {
            return getStrVal(objValue, "");
        }

        /// <summary>
        /// get string value for any object
        /// </summary>
        /// <param name="objValue">any object</param>
        /// <param name="sOption">default value for blank string</param>
        /// <returns>string result. blank for converting error</returns>
        public static string getStrVal(object objValue, string sOption)
        {
            string sResult = string.Empty;

            try
            {
                sResult = objValue.ToString().Trim();
            }
            catch (Exception ex)
            {
                string sError = ex.Message;
            }

            if (sResult == string.Empty)
            {
                if (sOption == "HTML")
                {
                    sResult = "&nbsp;";
                }
                else if (sOption == "PAGE")
                {
                    sResult = "1";
                }
                else
                {
                    sResult = sOption;
                }
            }

            return sResult;
        }
    }
}