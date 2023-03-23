using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

/// <summary>
/// Summary description for email
/// </summary>
public class email
{
	public email()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	/// <summary>
	/// Send email
	/// </summary>
	/// <param name="from">Sender address</param>
	/// <param name="to">Recepient address</param>
	/// <param name="bcc">Bcc recepient</param>
	/// <param name="cc">Cc recepient</param>
	/// <param name="subject">Subject of mail message</param>
	/// <param name="body">Body of mail message</param>
	public static string SendMailMessage(string from, string to, string bcc, string cc, string subject, string body)
	{
		try
		{
			// Instantiate a new instance of MailMessage
			MailMessage mMailMessage = new MailMessage();

			// Set the sender address of the mail message
			mMailMessage.From = new MailAddress(from);

			// Set the recepient address of the mail message
			foreach (string sTo in to.Split(';'))
			{
				if (sTo.Trim() != "")
				{
					mMailMessage.To.Add(new MailAddress(sTo));
				}
			}
			// Check if the bcc value is null or an empty string
			if ((bcc != null) && (bcc != string.Empty))
			{
				// Set the Bcc address of the mail message
				foreach (string sBcc in bcc.Split(';'))
				{
					if (sBcc.Trim() != "")
					{
						mMailMessage.Bcc.Add(new MailAddress(sBcc));
					}
				}
			}
			// Check if the cc value is null or an empty value
			if ((cc != null) && (cc != string.Empty))
			{
				// Set the CC address of the mail message
				foreach (string sCc in cc.Split(';'))
				{
					if (sCc.Trim() != "")
					{
						mMailMessage.CC.Add(new MailAddress(sCc));
					}
				}
			}
			// Set the subject of the mail message
			mMailMessage.Subject = subject;
			// Set the body of the mail message
			mMailMessage.IsBodyHtml = true;
			mMailMessage.Body = body;
			// Set the format of the mail message body as HTML
			mMailMessage.IsBodyHtml = true;
			// Set the priority of the mail message to normal
			mMailMessage.Priority = MailPriority.Normal;
			// Instantiate a new instance of SmtpClient
			//SmtpClient mSmtpClient = new SmtpClient("mailrelay.hke.local");
			//SmtpClient mSmtpClient = new SmtpClient("172.27.6.44");
			SmtpClient mSmtpClient = new SmtpClient("10.10.12.23");
			// Send the mail message
			mSmtpClient.Send(mMailMessage);

			return "";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	/// <summary>
	/// Send email width attachment
	/// </summary>
	/// <param name="from">Sender address</param>
	/// <param name="to">Recepient address</param>
	/// <param name="bcc">Bcc recepient</param>
	/// <param name="cc">Cc recepient</param>
	/// <param name="subject">Subject of mail message</param>
	/// <param name="body">Body of mail message</param>
	/// <param name="attachlist">Name of attach files. seperated by comma (,)</param>
	public static string SendMailMessageWidthAttach(string from, string to, string bcc, string cc, string subject, string body, string attachlist)
	{
		try
		{
			// Instantiate a new instance of MailMessage
			MailMessage mMailMessage = new MailMessage();

			// Set the sender address of the mail message
			mMailMessage.From = new MailAddress(from);

			// Set the recepient address of the mail message
			foreach (string sTo in to.Split(';'))
			{
				if (sTo.Trim() != "")
				{
					mMailMessage.To.Add(new MailAddress(sTo));
				}
			}
		
			// Check if the bcc value is null or an empty string
			if ((bcc != null) && (bcc != string.Empty))
			{
				// Set the Bcc address of the mail message
				foreach (string sBcc in bcc.Split(';'))
				{
					if (sBcc.Trim() != "")
					{
						mMailMessage.Bcc.Add(new MailAddress(sBcc));
					}
				}
			}

			// Check if the cc value is null or an empty value
			if ((cc != null) && (cc != string.Empty))
			{
				// Set the CC address of the mail message
				foreach (string sCc in cc.Split(';'))
				{
					if (sCc.Trim() != "")
					{
						mMailMessage.CC.Add(new MailAddress(sCc));
					}
				}
			}       

			// Set the subject of the mail message
			mMailMessage.Subject = subject;

			// Set the body of the mail message
			mMailMessage.IsBodyHtml = true;
			mMailMessage.Body = body;

			// Set the format of the mail message body as HTML
			mMailMessage.IsBodyHtml = true;

			// Set the priority of the mail message to normal
			mMailMessage.Priority = MailPriority.Normal;

			foreach (string attach in attachlist.Split(','))
			{
				if (attach.Length > 0)
				{
					Attachment attachment;
					attachment = new System.Net.Mail.Attachment(attach);
					mMailMessage.Attachments.Add(attachment);
				}
			}

			// Instantiate a new instance of SmtpClient
			SmtpClient mSmtpClient = new SmtpClient("mailrelay.hke.local");
			// Send the mail message
			mSmtpClient.Send(mMailMessage);

			return "";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}
}