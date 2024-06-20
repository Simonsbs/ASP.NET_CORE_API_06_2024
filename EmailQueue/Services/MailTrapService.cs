using System.Net.Mail;
using System.Net;
using EmailQueue.Entities;

namespace EmailQueue.Services;

public class MailTrapService : IMailService {
	public async Task SendEmail(EmailMessage message) {
		var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525) {
			Credentials = new NetworkCredential(
				"c5d271ec77937a",
				"2a4c26ca20ea03"
			),
			EnableSsl = true
		};
		await client.SendMailAsync(
			message.From,
			message.To,
			message.Subject,
			message.Body
		);
	}
}
