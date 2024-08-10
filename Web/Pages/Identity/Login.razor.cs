using Core.Handlers;
using Core.Requests.Account;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Web.Security;

namespace Web.Pages.Identity
{
    public partial class LoginPage : ComponentBase
    {
        #region Dependencies
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
        #endregion

        #region Properties
        public bool IsBusy { get; set; } = false;
        public LoginRequest InputModel { get; set; } = new();
        #endregion

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is { IsAuthenticated: true })
                NavigationManager.NavigateTo("/");
        }
        #endregion

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.LoginAsync(InputModel);

                if (result.IsSucess)
                {
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                    NavigationManager.NavigateTo("/");
                }
                else
                    Snackbar.Add(result.Message, Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
