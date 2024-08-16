using Core.Handlers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics;
using Web.Security;

namespace Web.Pages.Identity
{
    public partial class LogoutPage : ComponentBase
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

        #region overrides
        protected override async Task OnInitializedAsync()
        {
            try 
            {
                if (await AuthenticationStateProvider.CheckAuthenticatdAsync())
                {
                    await Handler.LogoutAsync();
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                }
                else
                {
                    Debug.WriteLine("User is not authenticated.");
                }

                NavigationManager.NavigateTo("/");
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"An error occurred during logout: {ex.Message}");
                Snackbar.Add("An error occurred during logout.", Severity.Error);
            }
        }
        #endregion
    }
}
