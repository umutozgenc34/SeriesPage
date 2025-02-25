using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Casts.Dtos;
using SeriesPage.Service.Casts.Abstracts;

namespace SeriesPage.Api.Controllers;

public class CastsController(ICastService castService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllCasts() => CreateActionResult(await castService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCastById([FromRoute] int id) => CreateActionResult(await castService.GetByIdAsync(id));

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateCast([FromForm] CreateCastRequest request) => CreateActionResult(await castService.AddAsync(request));

    [HttpPut]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateCast([FromForm] UpdateCastRequest request) => CreateActionResult(await castService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCast([FromRoute] int id) => CreateActionResult(await castService.DeleteAsync(id));
}
