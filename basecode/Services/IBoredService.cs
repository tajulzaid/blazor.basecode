using basecode.Model;

namespace basecode.Services
{
    public interface IBoredService
    {
        Task<Bored> GetSuggestionAsync();
    }
}