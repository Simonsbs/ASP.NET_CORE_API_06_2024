using AutoMapper;
using EmailQueue.Entities;
using EmailQueue.Models;
using EmailQueue.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmailQueue.Controllers;

[ApiController]
[Route("/api/emails")]
public class EmailMessageController : ControllerBase {
	private readonly IEmailMessageRepository _repo;
	private readonly IMapper _mapper;

	public EmailMessageController(IEmailMessageRepository repo, IMapper mapper) {
		_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	[HttpPost]
	public async Task<ActionResult<EmailMessageDTO>> CreateMessage
		(EmailMessageForCreateDTO message) {

		EmailMessage messageToAdd = _mapper.Map<EmailMessage>(message);
		
		await _repo.CreateEmail(messageToAdd);

		return Ok(_mapper.Map<EmailMessageDTO>(messageToAdd));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<EmailMessageDTO>> GetMessage(int id) {
		EmailMessage? message = await _repo.GetEmail(id);

		if (message == null) {
			return NotFound();
		}

		return Ok(_mapper.Map<EmailMessageDTO>(message));
	}

	[HttpGet("pending")]
	public async Task<ActionResult<IEnumerable<EmailMessageDTO>>> GetPendingMessages() {
		IEnumerable<EmailMessage> messages = await _repo.GetPendingMessages();

		return Ok(_mapper.Map<IEnumerable<EmailMessageDTO>>(messages));
	}
}
