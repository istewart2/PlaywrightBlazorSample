using Microsoft.Playwright;

namespace PlaywrightSpecflowV2.Pages
{
    public class CounterPage
    {
        public string PagePath => "http://localhost:5201/counter";

        private readonly IPage _page;
        private readonly ILocator _increaseButton;
        private readonly ILocator _counterValue;

        public CounterPage(IPage page)
        {
            _page = page;
            _increaseButton = _page.Locator("#increase-btn");
            _counterValue = _page.Locator("#counter-val");
        }

        public async Task ClickIncreaseButton() => await _increaseButton.ClickAsync();

        public async Task<int> CounterValue() => int.Parse(await _counterValue.InnerTextAsync());
    }
}
