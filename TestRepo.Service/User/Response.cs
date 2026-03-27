namespace TetPee.Service.User;

public class Response
{
    public static class Message
    {
        public static string CreateSuccess = "Created";
    }

    public class UserResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}