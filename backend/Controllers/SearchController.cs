using Backend.Models.Requests;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api")]
public class SearchController(SearchService searchService) : ControllerBase
{
    private readonly SearchService _searchService = searchService;

   [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] SearchRequest request)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var (ytsResponse, rarbgResponse) = await _searchService.ExecuteSearch(request.Query, request.IsMovieSearch);
        double searchTime = watch.ElapsedMilliseconds / 1000.0;
        watch.Stop();
        Console.WriteLine($"Total search time : {searchTime}");

        return Ok(new
        {
            ytsMovies = ytsResponse?.YTSmovies,
            rarbgMovies = rarbgResponse?.GenericMovies
        });
    }
}