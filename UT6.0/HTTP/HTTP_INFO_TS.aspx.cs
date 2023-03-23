using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HTTP_HTTP_INFO_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btn_HTTP_Click(object sender, EventArgs e)
    {
        string domain_Name = "Domain Name :: " + Request.Url.Host.ToString();
        string domainandPort = "Domain Name and Port :: " + Request.Url.Authority.ToString();
        string domainAbs = "Domain Name and port and address ::" + Request.Url.AbsolutePath.ToString();
        string port = "port :: " + Request.Url.Port.ToString();
        string applicationPath = "현재 응용 프로그램의 가상 경로 값 ::" + Request.ApplicationPath;
        string AbsoluteUri = "도메인명과 포트 그리고 쿼리스트링값이 포함된 전체 주소 :: " + Request.Url.AbsoluteUri.ToString();
        string PathAndQuery = "도메인명과 포트번호가 제외되고 쿼리스트링이 포함된 주소 :: " + Request.Url.PathAndQuery.ToString();

        Response.Write(domain_Name + "<BR>");
        Response.Write(domainandPort + "<BR>");
        Response.Write(domainAbs + "<BR>");
        Response.Write(port + "<BR>");
        Response.Write(applicationPath + "<BR>");
        Response.Write(AbsoluteUri + "<BR>");
        Response.Write(PathAndQuery + "<BR>");
    }
}