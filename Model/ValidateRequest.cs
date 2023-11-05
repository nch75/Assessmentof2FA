namespace TwoFactorService.Model
{
    public class ValidateRequest:PhoneRequest
    {
        public string Code { get; set; }

    }
}
