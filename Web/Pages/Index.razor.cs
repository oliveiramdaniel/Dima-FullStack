using Core.Handlers;
using Core.Models.Reports;
using Core.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Web.Pages;

public partial class IndexPage : ComponentBase
{
    #region Properties

    public bool ShowValues { get; set; } = true;
    public FinancialSummary? Summary { get; set; }

    #endregion

    #region Services

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IReportHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        var request = new GetFinancialSummaryRequest();
        var result = await Handler.GetFinancialSummaryReportAsync(request);
        if (result.IsSucess)
            Summary = result.Data;
    }

    #endregion

    #region Methods

    public void ToggleShowValues()
        => ShowValues = !ShowValues;

    #endregion
}