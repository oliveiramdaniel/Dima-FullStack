using System.Net.Http.Json;
using Core.Handlers;
using Core.Models.Reports;
using Core.Requests.Reports;
using Core.Responses;

namespace Web.Handlers;

public class ReportHandler(IHttpClientFactory httpClientFactory) : IReportHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(
        GetIncomesAndExpensesRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<IncomesAndExpenses>?>>($"v1/reports/incomes-expenses")
               ?? new Response<List<IncomesAndExpenses>?>(null, 400, "Unable to obtain the data.");
    }

    public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(
        GetIncomesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<IncomesByCategory>?>>($"v1/reports/incomes")
               ?? new Response<List<IncomesByCategory>?>(null, 400, "Unable to obtain the data.");
    }

    public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(
        GetExpensesByCategoryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<List<ExpensesByCategory>?>>($"v1/reports/expenses")
               ?? new Response<List<ExpensesByCategory>?>(null, 400, "Unable to obtain the data.");
    }

    public async Task<Response<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
    {
        return await _client.GetFromJsonAsync<Response<FinancialSummary?>>($"v1/reports/summary")
               ?? new Response<FinancialSummary?>(null, 400, "Unable to obtain the data.");
    }
}