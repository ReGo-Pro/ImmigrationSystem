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
using ReGoTech.ImmigrationSystem.Services;
using System.Net.Http;

namespace ReGoTech.ImmigrationSystem.Tests
{
	public class EmailServiceTests
	{
		[Fact]
		public async Task Should_Send_Email() {
			string verificationLink = $"https://localhost:7225/api/v1/Account/VerifyEmail?UID=testUid&verificationCode={Guid.NewGuid().ToString()}";
			var subject = "Please verify your email";
			var body = @$"
<pre>Dear User,

Thank you for registering with our platform. To activate your account, please click on the link below:
<a href='{verificationLink}'>Verify my email address</a>
Please note that this link will expire in 1 hour.</p>
If you did not sign up for an account with us, please ignore this email.

Yours sincerely,
ReGoTech.net Team</pre>
";

			var mailService = new EmailService();
			await mailService.SendAsync("test@test.com", subject, body);
		}
	}
}
