using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Summaries.Dtos;
using SeriesPage.Service.Summaries.Abstracts;

namespace SeriesPage.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SummaryController(ISummaryService summaryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllSummaries() => CreateActionResult(await summaryService.GetAllAsync());
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSummaryById([FromRoute] int id) => CreateActionResult(await summaryService.GetByIdAsync(id));
    [HttpPost]
    public async Task<IActionResult> CreateSummary([FromBody] CreateSummaryRequest request) => CreateActionResult(await summaryService.AddAsync(request));
    [HttpPut]
    public async Task<IActionResult> UpdateSummary([FromBody] UpdateSummaryRequest request) => CreateActionResult(await summaryService.UpdateAsync(request));
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSummary([FromRoute] int id) => CreateActionResult(await summaryService.DeleteAsync(id));
}