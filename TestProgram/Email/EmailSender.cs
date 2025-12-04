using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.Email
{
	public class EmailSender
	{
		public static void SendEmail()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Foxtrox", "noreply@foxtrox.dk"));
			message.To.Add(new MailboxAddress("Mikkel", "thenuker95@gmail.com"));
			message.Subject = "Testmail";

			var body = new TextPart("plain")
			{
				Text = "Hej, dette er en testmail 28."
			};
			message.Body = body;

			using (var client = new SmtpClient())
			{
				client.Timeout = 6000;
				client.Connect("smtp.simply.com", 587, SecureSocketOptions.StartTls);
				Console.WriteLine("Connected");

				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Authenticate("noreply@foxtrox.dk", "Foxtrox.dk");
				Console.WriteLine("Authed");

				try
				{
					client.Send(message);

					Console.WriteLine("Sendt");
				}
				catch (IOException ioex)
				{

					Console.WriteLine("Sendt but broke");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Unnown exceptin");
				}

				try
				{
					client.Disconnect(true);
					Console.WriteLine("Disconnect");
				}
				catch (Exception ex)
				{

					Console.WriteLine("Disconnect via ex");
				}

			}

			Console.WriteLine("Mail should be sent");


			//using (var client = new SmtpClient())
			//{
			//	client.Timeout = 10000;

			//	await client.ConnectAsync("smtp.simply.com", 587, SecureSocketOptions.StartTls);
			//	client.AuthenticationMechanisms.Remove("XOAUTH2");

			//	await client.AuthenticateAsync("noreply@foxtrox.dk", "Foxtrox.dk");

			//	try
			//	{
			//		await client.SendAsync(message);
			//	}
			//	catch (Exception ex)
			//	{
			//		Console.WriteLine("SendAsync warning: " + ex.Message);
			//	}

			//	try
			//	{
			//		await client.DisconnectAsync(true);
			//	}
			//	catch { }
			//}
		}
	}
}
