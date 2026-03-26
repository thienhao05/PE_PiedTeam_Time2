namespace TetPee.Service.User;

public interface IService
{
    public Task<string> CreateUser(Request.UserRequest request);
}