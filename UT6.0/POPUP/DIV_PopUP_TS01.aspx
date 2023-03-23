<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DIV_PopUP_TS01.aspx.cs" Inherits="POPUP_DIV_PopUP_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="Stylesheet" href="../css/Style.css" />

    <script type="text/javascript" src="../Js/Plugin/jquery-1.5.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="btn_Registration" type="button" class="button_blue3" title="등록" value="등록" />
        </div>

         <script type="text/javascript">
             $(document).ready(function () {
                 OnPageInit();
                 //수정변경 div
                 $('#dv_ADAS_UpdateClose').click(function () {
                     if ($('#dv_ADAS_Update').is(':visible')) {
                         $('#dv_ADAS_Update').slideUp();
                     }
                 });
                 //등록 div 
                 $('#dv_ADAS_CreateClose').click(function () {
                     if ($('#dv_ADAS_Create').is(':visible')) {
                         $('#dv_ADAS_Create').slideUp();
                     }
                 });
             });

             function OnPageInit() {
                 //등록 버튼
                 $('#btn_Registration').click(function () {
                     alert("POPUP");
                     Create();
                 });
             }

             //------ADAS 등록-------2018.11.20 추가//
             function Create(obj) {
                 if (!$('#dv_ADAS_Create').is(':visible')) {
                     //var top = obj.parent().offset().top + obj.parent().height() + 10;
                     $('#dv_ADAS_Create').css({ 'top': 170 + 'px', 'left': 500 + 'px' });
                     $('#dv_ADAS_Create').slideDown();
                     $('#btn_CreateOK').unbind('click').click(function () {
                         if ($('#txt_create_mid').val() === '') {
                             alert('ID를 입력하세요');//아이디를 입력하세요
                             $('#txt_create_mid').focus();
                             return false;
                         }
                         if ($('#txt_create_mid').val().length < 4) {
                             alert('ID는 4자리이상 입력하세요. ');//ID 4자리 이상 입력하세요
                             $('#txt_create_mid').focus();
                             return false;
                         }
                         if ($('#txt_create_pwd').val() === '') {
                             alert('인증번호를 입력하세요!');//
                             $('#txt_create_pwd').focus();
                             return false;
                         }
                         if ($('#txt_create_pwd').val().length < 4) {
                             alert('인증번호는 4자리이상 입력하세요');//비밀번호 4자리 이상 입력하세요!
                             $('#txt_create_pwd').focus();
                             return false;
                         }
                         var post = 'mid=' + encodeURIComponent($('#txt_create_mid').val())
                             + '&writer=' + encodeURIComponent($('#hid_memberid').val())//ctl00_ContentPlaceHolder1_hid_memberid
                             + '&pd=' + encodeURIComponent($('#txt_create_pwd').val());
                         $.ajax({
                             url: 'ADAS_Ajax.aspx?cmd=createinfo', type: "POST", data: post, dataType: 'text', success: function (result) {
                                 if (result == null || result == "") {
                                     alert('처리중 오류사항이 발생되었습니다.');//처리 중 오류사항이 발생하였습니다\n\n변경하려는 정보가 중복된 아이디인지 확인하세요
                                     return false;
                                 }
                                 else {
                                     if (result == "OK") {
                                         alert('등록완료 되었습니다.');//등록완료 되었습니다.
                                         document.location.href = 'ADAS_List.aspx?au=' + encodeURIComponent($('#hid_au').val());
                                     }
                                     else {
                                         if (result == "ER_ID") {
                                             alert('중복된 아이디입니다.정보를 확인하세요');//중복된 아이디입니다.정보를 확인하세요
                                             $('#txt_create_mid').focus();
                                             return false;
                                         }
                                         else {
                                             alert("등록에 실패하였습니다.");//처리에  실패하였습니다
                                             return false;
                                         }
                                     }
                                 }
                             }
                         });

                     });
                 }
                 else {
                     $('#dv_ADAS_Create').slideUp();
                 }

                 //2. 끝//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
             }
          </script>
    </form>
    <!--등록처리 화면 시작---->
    <div id="dv_ADAS_Create" style="display: none; width: 300px; z-index: 0; position: absolute; background-color: #efefef;"> 
   
        <div style="background-color: #ffffff; font-weight: bold; text-align: right; cursor: pointer;"
            id="dv_ADAS_CreateClose">
            [닫기]
        </div>
        <table style="width: 300px;" class="Blue_boarder_line">
            <tr>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">ID
                </td>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    <input type="text" id="txt_create_mid" class="stdTextBox_Type1" maxlength="15" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">인증번호
                </td>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    <input type="text" id="txt_create_pwd" class="stdTextBox_Type1" maxlength="20" />
                </td>
            </tr>
            <tr>
                <td style="width: 300px; text-align: center;" class="Blue_boarder_header_cell" colspan="2">
                    <input type="button" id="btn_CreateOK" title="OK" class="button_blue3" value="확인" />
                    <input type="button" id="btn_CreateCancel" title="Cancel" class="button_blue3" value="취소" />
                </td>
            </tr>
        </table>
    </div>
    <!--등록 끝---->
      <!--수정처리 화면 시작---->
    <div id="dv_ADAS_Update" style="display:block; width: 300px; z-index: 0; position: absolute;  background-color: #efefef;"> 
    
        <div style="background-color: #ffffff; font-weight: bold; text-align: right; cursor: pointer;"
            id="dv_ADAS_UpdateClose">
            [닫기]</div>
        <table style="width: 300px;" class="Blue_boarder_line">
            <tr>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    ID
                </td>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    <input type="text" id="txt_mid" class="stdTextBox_Type1" maxlength="15" />
                </td>
            </tr>
            <tr>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    인증번호
                </td>
                <td style="width: 150px; text-align: center;" class="Blue_boarder_header_cell">
                    <input type="text" id="txt_pwd" class="stdTextBox_Type1" maxlength="20" />
                </td>
            </tr>
            <tr>
                <td style="width: 200px; text-align: center;" class="Blue_boarder_header_cell">
                    시리얼번호
                </td>
                <td style="width: 200px; text-align: center;" class="Blue_boarder_header_cell">
                    <input type="text" id="txt_sn" class="stdTextBox_Type1" maxlength="8" />
                </td>
            </tr>
            <tr>
                <td style="width: 300px; text-align: center;" class="Blue_boarder_header_cell" colspan="2">
                    <input type="button" id="btn_ConfirmOK" title="확인" class="button_blue3" value="확인" />
                    <input type="button" id="btn_ConfirmCancel" title="취소" class="button_blue3" value="취소" />
                </td>
            </tr>
        </table>
    </div>
    <!--수정 끝---->

</body>
</html>
