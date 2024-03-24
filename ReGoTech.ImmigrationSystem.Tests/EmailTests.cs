using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MailKit.Net.Smtp;

namespace ReGoTech.ImmigrationSystem.Tests
{
	public class EmailTests
	{
		[Fact]
		public async Task  Should_Send_Email() {
			var success = false;
			var subject = "Test email";
			var body = @"Please go to this website: <a href='http://www.regotech.net'>Verify my email</a>";
			var email = "r.ghochkhani@gmail.com";

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
				smtp.Authenticate("kolby.hintz@ethereal.email", "gKqneDk2p6sYYPWteS");
				await smtp.SendAsync(message);
				success = true;
			}
			catch (Exception) {

			}

			Assert.True(success);
		}
	}
}
