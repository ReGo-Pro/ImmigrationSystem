﻿using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace ReGoTech.ImmigrationSystem.Services
{
	public class EmailService : IEmailService
	{
		// TODO: make this service configurable so that Program.cs can pass configurations to it (like smtp service, username, password, etc.)
		public async Task SendAsync(string email, string subject, string body) {
			try {
				var message = new MimeMessage();
				message.From.Add(MailboxAddress.Parse("welcome@regotech.net"));
				message.To.Add(MailboxAddress.Parse(email));
				message.Subject = subject;
				message.Body = new TextPart(TextFormat.Html) {
					Text = body
				};

				var smtp = new SmtpClient();
				smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
				smtp.Authenticate("mallory.grimes67@ethereal.email", "u8SaAfVcAANX5YaMCR");
				await smtp.SendAsync(message);
			}
			catch (Exception) {
				throw;
			}
		}
	}
}
