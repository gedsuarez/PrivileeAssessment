using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PrivileeAssessment.Support.Utilities
{
    [Binding]
    public class Hooks
    {
        public IPage Page { get; private set; } = null!;
        private readonly bool headlessValue = Convert.ToBoolean(Environment.GetEnvironmentVariable("HEADLESS"));

        [BeforeScenario]
        public async Task SetupTestAsync()
        {
            IPlaywright playwright = await Playwright.CreateAsync();
            IBrowser browser = await playwright.Chromium.LaunchAsync(new() { Headless = headlessValue });
            IBrowserContext context = await browser.NewContextAsync();
            
            Page = await context.NewPageAsync();
        }
        [AfterScenario]
        public async Task TearDownTestAsync()
        {
            await Page.ScreenshotAsync(new()
            {
                Path = "screenshot.png",
                FullPage = true,
            });
            await Page.CloseAsync();
        }
    }
}
