using basecode.Model;

namespace basecode.Services
{
    public class DataActivityService
    {
        private readonly IBoredService _repository;
        public DataActivityService(IBoredService repository)
        {
            _repository = repository;
        }

        public async Task<Bored> GetDataActivityAsync()
        {
            var result = await _repository.GetSuggestionAsync();
            return result;
        }
    }
}
