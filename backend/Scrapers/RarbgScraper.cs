using System.Diagnostics;
using System.Net;
using Backend.Models;
using Backend.Models.Responses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Backend.Scrapers
{

   public class RarbgScraper : IDisposable
{
    private IWebDriver _driver;

    public RarbgScraper()
    {
        _driver = SeleniumDriver.CreateNewDriver();
    }
        public GenericResponse RarbgtScraper(string query, bool isMovieSearch)
        {
            query= WebUtility.UrlEncode(query);
            var genericResponse = new GenericResponse();
            Console.WriteLine("Search start RARBG");
            string filter = isMovieSearch ? "category[]=movies" : "category[]=tv";
            _driver.Navigate().GoToUrl($"https://en.rarbg.gg/search/?search={query}&{filter}&order=seeders&by=DESC");

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("lista2t")));

            var movies = _driver.FindElements(By.ClassName("lista2"));
            foreach (var movie in movies)
            {
                var rarbgMovie = new GenericMovie();
                // Title + Url
                var titleTd = movie.FindElement(By.CssSelector("a[title]"));
                rarbgMovie.Title = titleTd.GetAttribute("title");
                rarbgMovie.MoviePageUrl = titleTd.GetAttribute("href");
                // Size
                var sizeTd = movie.FindElement(By.CssSelector("td.lista[width='100px']"));
                rarbgMovie.Size = sizeTd.Text.Trim();
                // Seeders
                var seedersTd = movie.FindElement(By.CssSelector("td.lista[width='50px']"));
                rarbgMovie.Seeders = seedersTd.Text.Trim();

                genericResponse.GenericMovies.Add(rarbgMovie);
            }
            // Remove low quality
            genericResponse.GenericMovies.RemoveAll(movie =>
            movie.Title.Contains("720p") ||
            movie.Title.Contains("480p"));

            // Loop for MagnetURLs
            foreach (var rarbgMovie in genericResponse.GenericMovies)
            {
                _driver.Navigate().GoToUrl(rarbgMovie.MoviePageUrl);
                IWebElement magnetElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href^='magnet:']")));
                rarbgMovie.MagnetUrl = magnetElement.GetAttribute("href");
            }
            Console.WriteLine($"Search end RARBG \nResult count RARBG: {genericResponse.GenericMovies.Count}");
            Dispose();

            return genericResponse;
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
