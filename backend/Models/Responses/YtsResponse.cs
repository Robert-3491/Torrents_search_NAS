using Backend.Models.YtsModels;

namespace Backend.Models.Responses;

public class YtsResponse
{
    public List<YTSmovie> YTSmovies { get; set; }

    public YtsResponse()
    {
        YTSmovies = new List<YTSmovie>();
    }
} 
