using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Scenes.Dtos;
using SeriesPage.Service.Scenes.Abstracts;

namespace SeriesPage.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScenesController(ISceneService sceneService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllScenes() => CreateActionResult(await sceneService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSceneById([FromRoute] int id) => CreateActionResult(await sceneService.GetByIdAsync(id));

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateScene([FromForm] CreateSceneRequest request) => CreateActionResult(await sceneService.AddAsync(request));

    [HttpPut]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateScene([FromForm] UpdateSceneRequest request) => CreateActionResult(await sceneService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteScene([FromRoute] int id) => CreateActionResult(await sceneService.DeleteAsync(id));
}