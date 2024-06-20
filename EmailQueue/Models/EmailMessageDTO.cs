using System.ComponentModel.DataAnnotations;

namespace EmailQueue.Models;

public class EmailMessageDTO {
	public int ID { get; set; }

	[Required]
	[EmailAddress]
	public string From { get; set; }

	[Required]
	[EmailAddress]
	public string To { get; set; }

	[Required]
	[MaxLength(100)]
	public string Subject { get; set; }

	[Required]
	public string Body { get; set; }

	public DateTime Created { get; set; }

	public bool Sent { get; set; }
}
