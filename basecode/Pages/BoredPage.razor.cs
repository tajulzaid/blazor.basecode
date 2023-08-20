using basecode.Services;
using Microsoft.AspNetCore.Components;

namespace basecode.Pages
{
    public partial class BoredPage : ComponentBase
    {
        [Inject]
        public IBoredService BoredService { get; set; } = null!;

        public Model.Bored BoredActivity { get; private set; } = new Model.Bored();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            BoredActivity = await BoredService.GetSuggestionAsync();
        }
    }
}
