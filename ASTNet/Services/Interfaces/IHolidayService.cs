namespace ASTNet.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<object> GetHolidaysAsync(int year, string countryCode);
    }
}
