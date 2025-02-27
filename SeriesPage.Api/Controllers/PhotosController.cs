using Microsoft.AspNetCore.Mvc;
using SeriesPage.Model.Photos.Dtos;
using SeriesPage.Service.Photos.Abstracts;

namespace SeriesPage.Api.Controllers;

public class PhotosController(IPhotoService photoService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllPhotos() => CreateActionResult(await photoService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPhotoById([FromRoute] int id) => CreateActionResult(await photoService.GetByIdAsync(id));

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreatePhoto([FromForm] CreatePhotoRequest request) => CreateActionResult(await photoService.AddAsync(request));
    [HttpPut]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdatePhoto([FromForm] UpdatePhotoRequest request) => CreateActionResult(await photoService.UpdateAsync(request));
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePhoto([FromRoute] int id) => CreateActionResult(await photoService.DeleteAsnyc(id));
}
