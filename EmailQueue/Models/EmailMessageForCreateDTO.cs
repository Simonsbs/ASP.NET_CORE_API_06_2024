using System.ComponentModel.DataAnnotations;

namespace EmailQueue.Models;

public class EmailMessageForCreateDTO {
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
}
