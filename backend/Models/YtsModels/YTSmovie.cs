namespace Backend.Models.YtsModels;

public class YTSmovie
{
    public string Title { get; set; }
    public string ImageURL { get; set; }
    public string Year { get; set; }
    public string MoviePageUrl { get; set; }
    public List<YTSquality> Qualities { get; set; } = new List<YTSquality>();

}