using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Episodes.Dtos;
using SeriesPage.Service.Episodes.Abstracts;

namespace SeriesPage.Api.Controllers;


public class EpisodesController(IEpisodeService episodeService) : CustomBaseController
{
    private const long MaxVideoUploadSize = 500L * 1024 * 1024;

    [HttpGet]
    public async Task<IActionResult> GetAllEpisodes() => CreateActionResult(await episodeService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEpisodeById([FromRoute] int id) => CreateActionResult(await episodeService.GetByIdAsync(id));

    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(MaxVideoUploadSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxVideoUploadSize)]
    public async Task<IActionResult> CreateEpisode([FromForm] CreateEpisodeRequest request) => CreateActionResult(await episodeService.AddAsync(request));

    [HttpPut]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(MaxVideoUploadSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = MaxVideoUploadSize)]
    public async Task<IActionResult> UpdateEpisode([FromForm] UpdateEpisodeRequest request) => CreateActionResult(await episodeService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEpisode([FromRoute] int id) => CreateActionResult(await episodeService.DeleteAsync(id));
}
