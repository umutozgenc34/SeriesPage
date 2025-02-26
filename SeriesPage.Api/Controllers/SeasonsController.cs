using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Seasons.Dtos;
using SeriesPage.Service.Seasons.Abstracts;

namespace SeriesPage.Api.Controllers;

public class SeasonController(ISeasonService seasonService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllSeasons() => CreateActionResult(await seasonService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSeasonById([FromRoute] int id) => CreateActionResult(await seasonService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateSeason([FromBody] CreateSeasonRequest request) => CreateActionResult(await seasonService.AddAsync(request));

    [HttpPut]
    public async Task<IActionResult> UpdateSeason([FromBody] UpdateSeasonRequest request) => CreateActionResult(await seasonService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSeason([FromRoute] int id) => CreateActionResult(await seasonService.DeleteAsync(id));

    [HttpGet("with-episodes")]
    public async Task<IActionResult> GetAllSeasonsWithEpisodes() =>
           CreateActionResult(await seasonService.GetAllWithEpisodesAsync());

    [HttpGet("with-episodes/{seasonNumber:int}")]
    public async Task<IActionResult> GetSeasonWithEpisodesBySeasonNumber([FromRoute] int seasonNumber) =>
        CreateActionResult(await seasonService.GetWithEpisodesBySeasonNumberAsync(seasonNumber));
}