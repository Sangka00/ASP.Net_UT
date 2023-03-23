using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sting_UT_split_TS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Info = "10.206.214.232/20.5/57^/Started/Started/";

        string []In = Info.Split('/');
        for(int i=0; i < In.Length  ; i++)
        {
         //   Response.Write(In[i] + "<br>");
        }

        string _ServerIP = In[0];
        string _FreeMemory_Percent = In[1];
        string _Cpu_used_Percent = In[2];
        string _appPool_state = In[3].ToUpper();
        string _WEBSite_state = In[4].ToUpper();

        Response.Write("SERVR IP" + _ServerIP+"<br>");
        Response.Write("FreeMemory%" + _FreeMemory_Percent + "<br>");
        Response.Write("Cpu Used Percent" + _Cpu_used_Percent + "<br>");
        Response.Write("AppPool state" + _appPool_state + "<br>");
        Response.Write("WebSite state" + _WEBSite_state + "<br>");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string Info = "FORTE(BDm) > 2020 > G 1.6 T-GDI GAMMA > Brake > ABS/ESC > C161108 CAN Time-out EMS > General Description";
        string[] In = Info.Split('>');
        string str = string.Empty;

        Response.Write("차종" + In[0] + "<br>");
        Response.Write("년식" + In[1] + "<br>");
        Response.Write("엔진" + In[2] + "<br>");
        for (int i = 3; i < In.Length; i++)
        {
            //   Response.Write(In[i] + "<br>");
           // if( i > 2) { 
               if(i !=3) { 
                   str += ">" + In[i];
              }
              else
               {
                    str +=  In[i];
                }
            
           // }
        }
        Response.Write(str);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string Info = "HI-DS Premium$EDR$KOTSA$G-scan M$HG$Smart D-logger$GDSM$Trigger$G-SCAN2$";

        Info = Info.Trim();
      

        string[] In = Info.Split('$');
        string str = string.Empty;
        Response.Write(In.Length.ToString());

        Response.Write("[0]" +In[0].ToString()+"<BR>");

        Response.Write("[1]" + In[1].ToString() + "<BR>");

        Response.Write("[2]" + In[2].ToString() + "<BR>");

        Response.Write("[3]" + In[3].ToString() + "<BR>");

        Response.Write("[4]" + In[4].ToString() + "<BR>");

        Response.Write("[5]" + In[5].ToString() + "<BR>");

        Response.Write("[6]" + In[6].ToString() + "<BR>");

        Response.Write("[7]" + In[7].ToString() + "<BR>");

        Response.Write("[8]" + In[8].ToString() + "<BR>");

        Response.Write("[9]" + In[9].ToString() + "<BR>");

       

        for (int i = 0; i < In.Length -1 ; i++)
        {
            if( i == In.Length-2)
            {
                str += "'" +In[i] +"'";
            }
            else
            {
                str += "'" + In[i] + "' , ";
            }

        }
        Response.Write(str);

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string Info = "content_no=DTC%7cENG%7c9520%7c2021%7c%7cesft%7c6%7c%7c&sitinfolist=14%5e1465%5e14650600%5enone%5e601%5e19%5eENG%5eHY%5eTM23%5e2021%5eesft%5e6%5eP1120%5enone%5enone%5eDTC%5e0%5e%24&cat1=2021+%3e+SBW+Control+Unit+(SCU)+%3e+SBW+Control+Unit+(SCU)&firstnodedesc=Diagnostic+Flow-chart";
        Info = Info.Trim();


        string[] In = Info.Split('&');
      
        string[] In2 = In[0].Split('=');
        Response.Write( In2[0].ToString() + "<BR>");
        Response.Write(In2[1].ToString() + "<BR>");
    }

}