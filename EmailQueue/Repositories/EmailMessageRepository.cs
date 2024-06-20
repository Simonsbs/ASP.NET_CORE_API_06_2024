using EmailQueue.Contexts;
using EmailQueue.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailQueue.Repositories;

public interface IEmailMessageRepository {
	Task<EmailMessage> CreateEmail(EmailMessage message);

	Task<EmailMessage?> GetEmail(int id);

	Task<IEnumerable<EmailMessage>> GetPendingMessages(int? amount = null);

	Task MarkAsSent(int id);
}

public class EmailMessageRepository : IEmailMessageRepository {
	private readonly MainContext _db;

	public EmailMessageRepository(MainContext db) {
		_db = db ?? throw new ArgumentNullException(nameof(db));
	}

	public async Task<EmailMessage> CreateEmail(EmailMessage message) {
		message.Created = DateTime.UtcNow;
		message.Sent = false;

		await _db.EmailMessages.AddAsync(message);
		await _db.SaveChangesAsync();
		return message;
	}

	public async Task<EmailMessage?> GetEmail(int id) {
		EmailMessage? message = await _db.EmailMessages.FirstOrDefaultAsync(e => e.ID == id);
		return message;
	}

	public async Task<IEnumerable<EmailMessage>> GetPendingMessages(int? amount = null) {
		var messages = _db.EmailMessages
			.Where(m => !m.Sent);

		if (amount.HasValue) {
			messages = messages.Take(amount.Value);
		}

		return await messages.ToListAsync();
	}

	public async Task MarkAsSent(int id) {
		EmailMessage? message = await _db.EmailMessages.FirstOrDefaultAsync(e => e.ID == id);
		if (message != null) {
			message.Sent = true;
			await _db.SaveChangesAsync();
		}
	}
}
