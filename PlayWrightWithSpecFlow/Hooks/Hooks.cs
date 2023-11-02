using BoDi;
using Microsoft.Playwright;
using PlaywrightBlazorSample.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace AutomatedUITesting.Web.Tests.UI.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario("Counter")]
        public async Task BeforeCounterScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true, // display in browser
                //SlowMo = 2000 // add delay only to see playwright perform the actions
            });
            var pageObject = new CounterPageObject(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
        }

        //[AfterScenario]
        //public async Task AfterScenario(IObjectContainer container)
        //{
        //    var browser = container.Resolve<IBrowser>();
        //    await browser.CloseAsync();
        //    var playwright = container.Resolve<IPlaywright>();
        //    playwright.Dispose();
        //}
    }
}
