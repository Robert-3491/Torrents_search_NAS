namespace Backend.Drivers 
{ 
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public static class SeleniumDriver
    {
        private static ChromeDriver? _ytsDriver;
        private static ChromeDriver? _rarbgDriver;
        private static ChromeDriver? _testDriver;

        private static ChromeOptions GetDefaultChromeOptions()
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
            options.PageLoadStrategy = PageLoadStrategy.None;
            return options;
        }

        public static void InitializeYtsDriver()
        {
            _ytsDriver = new ChromeDriver(GetDefaultChromeOptions());
            Console.WriteLine("YTS Driver created");
        }

        public static void InitializeRarbgDriver()
        {
            _rarbgDriver = new ChromeDriver(GetDefaultChromeOptions());
            Console.WriteLine("RARBG Driver created");
        }

        public static void InitializeTestDriver()
        {
            _testDriver = new ChromeDriver(GetDefaultChromeOptions());
            Console.WriteLine("Test Driver created");
        }

        public static ChromeDriver GetYtsDriver() => _ytsDriver!;

        public static ChromeDriver GetRarbgDriver() => _rarbgDriver!;

        public static ChromeDriver GetTestDriver() => _testDriver!;

        public static void CloseAllDrivers()
        {
            _ytsDriver?.Quit();
            _ytsDriver?.Dispose();
            _ytsDriver = null;

            _rarbgDriver?.Quit();
            _rarbgDriver?.Dispose();
            _rarbgDriver = null;

            _testDriver?.Quit();
            _testDriver?.Dispose();
            _testDriver = null;

            Console.WriteLine("All drivers closed");
        }
    }
}