namespace E_Commerce_Website.ViewModel
{
    public class RegisterViewModel
    {
        public required string Username { set; get; }
        public required string Email { set; get; }
        public required string Password { set; get; }
        public required string ConfirmPassword { set; get; }
    }
}
