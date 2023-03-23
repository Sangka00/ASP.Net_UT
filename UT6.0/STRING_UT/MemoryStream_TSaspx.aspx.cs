using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class Sting_UT_MemoryStream_TSaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_MemoryStream_Click(object sender, EventArgs e)
    {
        //MemorySteam은 일련의 바이트 데이터를 메모리에 쓰고 읽는 기능을 제공
        byte[] cb = BitConverter.GetBytes('a');
        byte[] ib = BitConverter.GetBytes(1000);
        MemoryStream ms = new MemoryStream();
        ms.Write(cb, 0, cb.Length);
        ms.Write(ib, 0, ib.Length);
        //문자열 a와 정수형 1000 데이터를 바이트로 변환해 MemoryStream으로 메모리에 쓰고 있음
        // 메모리에 쓸 때는 Write메서드를 사용하여 0부터 각 데이터 배열길이까지 전체를 쓰도록 하고 있음

        ms.Position = 0;
        byte[] outcb = new byte[2];
        byte[] outib = new byte[4];

        ms.Read(outcb, 0, 2);
        ms.Read(outib, 0, 4);

        char c = BitConverter.ToChar(outcb, 0);
        int i = BitConverter.ToInt32(outib, 0);

        Lbl_mStream.Text = c.ToString() + "---" + i.ToString();
    
       
    }

    protected void BTN_SteamReader_Click(object sender, EventArgs e)
    {
        // 문자열 처리
        MemoryStream m = new MemoryStream();
        StreamWriter sw = new StreamWriter(m, Encoding.UTF8);

        sw.WriteLine("Hello World");  //문자열쓰기 전용, 정수형 등 다른 단일 데이터의 경우 Write메서드 사용
        sw.Flush();
        //StremWriter가 데이터를 쓸때는 곧장 MemoryStream에 기록하는 것이 아니라 내부적으로 갖고 있는 일정한 크기의
        //byte배열 버퍼에 데이터를 기록합니다.그러다 만약 일정한 크기에 도달하면 그때 MemorySteam에 기록하게 되는데
        //마지막에 있는 Flush()메서드는 쓸 데이터가 버퍼에 다 차지 않더라도 MemoryStream에 접근해 데이터를 기록하게 하는 메서드임

        m.Position = 0;

        StreamReader sr = new StreamReader(m, Encoding.UTF8);
        string s = sr.ReadToEnd();
        Lbl_StreamReader.Text = s;
        //StreamWriter로 쓴 데이터는 다시 StreamReader로 읽을 수 있다.
        //인코딩방식은 StreamWriter를 사용할때와 똑같이 지정해야 하며 데이터를 반드시 Position을 0으로 맞춰야 함

    }

    protected void Btn_BinaryWriter_Click(object sender, EventArgs e)
    {
        //BinaryWriter는 2진 데이터를 쓰기 위한 전용. BinaryWriter를 통해 데이터를 쓰는 경우 byte 배열
        //중간중간에 다음 몇바이트가 데이터바이트인지를 나타내는 구분자가 추가됩니다.
        // 때문에 뭔가 규격화된 데이터를 다루고자 할때는 BinaryWriter사용
        // 쓰기 작업에 대한 효율성도 좋아서 성능이 우선시 되는 상황에서는 BinaryWriter 좋은 선택
        MemoryStream mx = new MemoryStream();
        BinaryWriter bw = new BinaryWriter(mx);
        bw.Write("hello");
        bw.Write("world !" + Environment.NewLine);
        bw.Flush();

        mx.Position = 0;

        BinaryReader br = new BinaryReader(mx);
        string ss = br.ReadString();
        ss += br.ReadString();

        Lbl_BinaryWriter.Text = ss;

    }
}