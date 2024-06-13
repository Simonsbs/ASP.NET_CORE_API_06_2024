namespace ShopAPI.Services;

public interface IMailService {
    public void Send(string subject, string body);
}