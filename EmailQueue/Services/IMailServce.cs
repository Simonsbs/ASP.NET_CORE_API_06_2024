using EmailQueue.Entities;

namespace EmailQueue.Services;

public interface IMailService {
	Task SendEmail(EmailMessage message);
}
