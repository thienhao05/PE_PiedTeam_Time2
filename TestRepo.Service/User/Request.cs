namespace TetPee.Service.User;

public class Request
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class GetAllUserRequest
    {
        //string? searchTerm, int pageIndex, int pageSize
        public string? SearchTerm { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}