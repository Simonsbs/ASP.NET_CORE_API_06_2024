using EmailQueue.Entities;
using EmailQueue.Repositories;

namespace EmailQueue.Services;

public class EmailBackgroundService : BackgroundService {
	private readonly IServiceProvider _provider;

	public EmailBackgroundService(IServiceProvider provider) {
		_provider = provider ?? throw new ArgumentNullException(nameof(provider));
	}

	protected async override Task ExecuteAsync(CancellationToken stoppingToken) {
		using (IServiceScope scope = _provider.CreateScope()) {
			IMailService mail = scope.ServiceProvider.GetRequiredService<IMailService>();
			IEmailMessageRepository repo = scope.ServiceProvider.GetRequiredService<IEmailMessageRepository>();

			while (!stoppingToken.IsCancellationRequested) {
				IEnumerable<EmailMessage> messages = await repo.GetPendingMessages(10);

				foreach (var message in messages) {
					try {
						await mail.SendEmail(message);
						await repo.MarkAsSent(message.ID);
					} catch {
					}					
				}

				await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
			}
		}
	}
}
