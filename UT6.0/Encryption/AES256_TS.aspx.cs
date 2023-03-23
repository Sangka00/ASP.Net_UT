using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Encryption_AES256_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_enc_Click(object sender, EventArgs e)
    {
        //AES256 암호화
        string str = Txt_payload.Text.Trim();
        string encodedToken = AES256.AES256Encrypt(str);
        txt_re1.Text = encodedToken;
    }

    protected void Btn_un_Click(object sender, EventArgs e)
    {    //AES256 복호화
        string str = Txt_enc.Text;
        string decodedToken = AES256.AES256Decrypt(str);
        txt_re2.Text = decodedToken;
    }

    protected void But_URLEncoding_Click(object sender, EventArgs e)
    {
        string url_en = Txt_URLEncoding.Text.Trim();
        Lbl_URLEncoding.Text = HttpUtility.UrlEncode(url_en);
    }

    protected void But_URLDecoding_Click(object sender, EventArgs e)
    {
        string url_de = txt_URLDecoding.Text.Trim();
        Lbl_URLDecoding.Text = HttpUtility.UrlDecode(url_de);
    }
}