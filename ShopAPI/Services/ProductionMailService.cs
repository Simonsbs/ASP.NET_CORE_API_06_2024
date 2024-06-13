namespace ShopAPI.Services;

public class ProductionMailService : IMailService {
	private string from = "admin@mail.com";
	private string to = "IT@mail.com";

	public void Send(string subject, string body) {
		Console.WriteLine($"Mail from:{from} to:{to} - using production");
		Console.WriteLine(subject);
		Console.WriteLine("-----------------");
		Console.WriteLine(body);
	}
}

