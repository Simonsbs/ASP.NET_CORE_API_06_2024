using AutoMapper;
using EmailQueue.Entities;
using EmailQueue.Models;

namespace EmailQueue.Profiles;

public class EmailMessagesProfile : Profile {
	public EmailMessagesProfile() {
		CreateMap<EmailMessageForCreateDTO, EmailMessage>();
		CreateMap<EmailMessage, EmailMessageDTO>();		
	}

	
}
