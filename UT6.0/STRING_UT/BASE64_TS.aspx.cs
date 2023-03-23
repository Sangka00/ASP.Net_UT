using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

public partial class STRING_UT_BASE64_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Base64_Click(object sender, EventArgs e)
    {
        // Base64 - Byte data or stream data를 string형식으로 표현한것
        // 문자열을 Base64로 인코딩하기 위해서는 우선 문자열을 바이트배열로 전환해야 한다. 
        // 문자열을 바이트배열로 변환하기 위해서는 문자열 인코딩 아티클 에서 설명한 바와 같이
        // Encoding을 통해 변환하게 된다.
        // 일단 바이트 배열로 변환한 후에는 Convert.ToBase64String() 를 사용하여
        // 다시 Base64로 인코딩하면 된다


        // 문자열을 유니코드 인코딩으로 바이트배열로 변환
        //   byte[] bytes = Encoding.Unicode.GetBytes(Txt_P.Text);
        byte[] bytes = Encoding.UTF8.GetBytes(Txt_P.Text);

        // 바이트들을 Base64로 변환
        string base64 = Convert.ToBase64String(bytes);
        lbl_Base64.Text = base64;
    }

    protected void Btn_P_Click(object sender, EventArgs e)
    {
        // Base64 인코드된 문자열을 바이트배열로 변환
        byte[] orgBytes = Convert.FromBase64String(Txt_Base64.Text);
        // 바이트들을 다시 유니코드 문자열로
        // string orgStr = Encoding.Unicode.GetString(orgBytes);
        string orgStr = Encoding.UTF8.GetString(orgBytes);
        lbl_p.Text = orgStr;
    }
}