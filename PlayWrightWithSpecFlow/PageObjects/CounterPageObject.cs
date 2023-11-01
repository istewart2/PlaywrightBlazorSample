using Microsoft.Playwright;

namespace PlaywrightBlazorSample.Specs.PageObjects
{
    public class CounterPageObject : BasePageObject
    {
        public override string PagePath => "http://localhost:5201/counter";

        public CounterPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }

        public async Task ClickIncreaseButton() => await Page.ClickAsync("#increase-btn");

        public async Task<int> CounterValue() => int.Parse(await Page.InnerTextAsync("#counter-val"));


    }
}
