using System.Net;
using Backend.Models.Responses;
using Backend.Models.YtsModels;
using OpenQA.Selenium;

namespace Backend.Scrapers{

public class YtsScrapper : IDisposable
{
    private readonly IWebDriver _driver;

    public YtsScrapper()
        {
             _driver = SeleniumDriver.CreateNewDriver();
        }
        public YtsResponse ScrapeYTS(string query)
        {
            Console.WriteLine("Search start YTS");
           

            var queryUrl = WebUtility.UrlEncode(query);
            var ytsResponse = new YtsResponse();

            _driver.Navigate().GoToUrl($"https://yts.mx/browse-movies/{queryUrl}/all/all/0/latest/0/all");
            var movies = _driver.FindElements(By.ClassName("browse-movie-wrap"));

            foreach (var movie in movies)
            {
                var ytsMovie = new YTSmovie
                {
                    Title = movie.FindElement(By.ClassName("browse-movie-title")).Text,
                    Year = movie.FindElement(By.ClassName("browse-movie-year")).Text,
                    ImageURL = movie.FindElement(By.ClassName("img-responsive")).GetAttribute("src"),
                    MoviePageUrl = movie.FindElement(By.TagName("a")).GetAttribute("href")
                };

                // omit movies that do not match the search query (fuzzy matching - check if all words are present)
                if (TitleIncludesQuery(ytsMovie, query))
                {
                    ytsResponse.YTSmovies.Add(ytsMovie);
                }
            }

            // loop through the individual movie pages for magnet links and available qualities
            foreach (var ytsMovie in ytsResponse.YTSmovies)
            {
                _driver.Navigate().GoToUrl(ytsMovie.MoviePageUrl);
                var qualityCards = _driver.FindElements(By.ClassName("modal-torrent"));

                foreach (var qualityCard in qualityCards)
                {
                    var ytsQuality = new YTSquality
                    {
                        // Quality: 1080p or 2160p  
                        // textContent - access for hidden elements
                        Quality = qualityCard.FindElement(By.CssSelector(".modal-quality span")).GetAttribute("textContent"),
                        // QualityType: WEB or BluRay
                        QualityType = qualityCard.FindElement(By.ClassName("quality-size")).GetAttribute("textContent"),
                        Size = qualityCard.FindElements(By.ClassName("quality-size"))[1].GetAttribute("textContent"),
                        MagnetURL = qualityCard.FindElement(By.ClassName("magnet")).GetAttribute("href")
                    };

                    ytsMovie.Qualities.Add(ytsQuality);
                }
                // RemoveLowQuality option for each movie (if 1080 available)
                RemoveLowQuality(ytsMovie);
            }
            Dispose();
            Console.WriteLine($"Search end YTS, result count: {ytsResponse.YTSmovies.Count}");
            return ytsResponse;
        }
        
        // fuzzy matching - check if all words are present
        public bool TitleIncludesQuery (YTSmovie movie , string query)
        {
            string titleYearJoined = $"{movie.Title} {movie.Year}";
                var queryWords = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (queryWords.All(word => titleYearJoined.Contains(word, StringComparison.CurrentCultureIgnoreCase)))
            {
                return true;
            }
            return false;
        }
        public YTSmovie RemoveLowQuality(YTSmovie movie)
        {
            if (movie.Qualities.Any(q => q.Quality.Contains("1080")))
            {
                movie.Qualities.RemoveAll(q => q.Quality.Contains("720") || q.Quality.Contains("3D"));
            }
            return movie;
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
}
}