using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Awards.Dtos;
using SeriesPage.Service.Awards.Abstracts;

namespace SeriesPage.Api.Controllers;

public class AwardController(IAwardService awardService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAwards() => CreateActionResult(await awardService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAwardById([FromRoute] int id) => CreateActionResult(await awardService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAward([FromBody] CreateAwardRequest request) => CreateActionResult(await awardService.AddAsync(request));

    [HttpPut]
    public async Task<IActionResult> UpdateAward([FromBody] UpdateAwardRequest request) => CreateActionResult(await awardService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAward([FromRoute] int id) => CreateActionResult(await awardService.DeleteAsync(id));
}