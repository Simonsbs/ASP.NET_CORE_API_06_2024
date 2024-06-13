namespace ShopAPI.Services;

public class LocalMailService : IMailService {
    private readonly IConfiguration _config;
    private readonly string from;
    private readonly string to;

    public LocalMailService(IConfiguration config)    {
        _config = config ?? throw new ArgumentNullException(nameof(config));

        to = _config["mailSettings:toAddress"];
		from = _config["mailSettings:fromAddress"];
	}

    public void Send(string subject, string body) {
        Console.WriteLine($"Mail from:{from} to:{to} - using local");
        Console.WriteLine(subject);
        Console.WriteLine("-----------------");
        Console.WriteLine(body);
    }
}

