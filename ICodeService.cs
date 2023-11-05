namespace TwoFactorService
{
    public interface ICodeService
    {
        Task<string> GenerateAndStoreCodeAsync(string phone);
        Task<bool> IsValidCodeAsync(string phone, string code);
    }
}
