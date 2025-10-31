namespace Backend.Scrapers { 

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    public static class SeleniumDriver
{
        public static IWebDriver CreateNewDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
            options.AddUserProfilePreference("profile.managed_default_content_settings.cookies", 2);
            options.AddUserProfilePreference("profile.managed_default_content_settings.javascript", 1);
            options.AddUserProfilePreference("profile.managed_default_content_settings.plugins", 2);

            options.PageLoadStrategy = PageLoadStrategy.None; //the fastest

            return new ChromeDriver(options);
        }


        public static IWebDriver CreateNewFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");

            options.SetPreference("permissions.default.image", 2); 
            options.SetPreference("network.cookie.cookieBehavior", 2);
            options.SetPreference("javascript.enabled", true); 
            options.SetPreference("plugin.state.flash", 0); 
            options.SetPreference("dom.ipc.plugins.enabled.libflashplayer.so", false);
            options.SetPreference("media.autoplay.default", 0);

            options.PageLoadStrategy = PageLoadStrategy.None; // the fastest

            return new FirefoxDriver(options);
        }
    
    
}
}