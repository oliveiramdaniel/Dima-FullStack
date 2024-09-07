using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
//using Core.Requests.Stripe;
using Web.Pages.Orders;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace Web.Components.Orders;

public partial class OrderActionComponent : ComponentBase
{
    #region Parameters

    [CascadingParameter] public DetailsPage Parent { get; set; } = null!;

    [Parameter, EditorRequired] public Order Order { get; set; } = null!;

    #endregion

    #region Services

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private IOrderHandler OrderHandler { get; set; } = null!;
    //[Inject] public IStripeHandler StripeHandler { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Public Methods
    public async void OnCancelButtonClicked()
    {
        bool? result = await DialogService.ShowMessageBox(
            "ATTENTION",
            "Do you really want to cancel this order?",
            yesText: "YES", cancelText: "NO");

        if (result is not null && result == true)
            await CancelOrderAsync();
    }

    public async void OnRefundButtonClicked()
    {
        bool? result = await DialogService.ShowMessageBox(
            "ATTENTION",
            "Do you really want to refund this order?",
            yesText: "YES", cancelText: "NO");

        if (result is not null && result == true)
            await RefundOrderAsync();
    }


    #endregion

    #region Private Methods

    private async Task CancelOrderAsync()
    {
        var request = new CancelOrderRequest
        {
            Id = Order.Id
        };

        var result = await OrderHandler.CancelAsync(request);
        if (result.IsSucess)
            Parent.RefreshState(result.Data!);
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    public async void OnPayButtonClicked()
    {
        await PayOrderAsync();
    }

    private async Task RefundOrderAsync()
    {
        var request = new RefundOrderRequest
        {
            Id = Order.Id
        };

        var result = await OrderHandler.RefundAsync(request);
        if (result.IsSucess)
            Parent.RefreshState(result.Data!);
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    private async Task PayOrderAsync()
    {
        await Task.Delay(1);
        Snackbar.Add("Payment is not implemented yet", Severity.Error);
    }

    #endregion
}