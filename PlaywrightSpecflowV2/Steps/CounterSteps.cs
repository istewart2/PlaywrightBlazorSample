using FluentAssertions;
using PlaywrightSpecflowV2.Drivers;
using PlaywrightSpecflowV2.Pages;
using TechTalk.SpecFlow;

namespace PlayWrightWithSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class CounterSteps
    {
        private readonly Driver _driver;
        private readonly CounterPage _counterPage;

        public CounterSteps(Driver driver)
        {
            _driver = driver;
            _counterPage = new CounterPage(_driver.Page);
        }

        [Given(@"a user in the counter page")]
        public async Task GivenAUserInTheCounterPage()
        {
            await _driver.Page.GotoAsync(_counterPage.PagePath);
        }

        [When(@"the increase button is clicked (.*) times")]
        public async Task WhenTheIncreaseButtonIsClickedTimes(int times)
        {
            for (var i = 0; i < times; i++)
            {
                await _counterPage.ClickIncreaseButton();
            }
        }

        [Then(@"the counter value is (.*)")]
        public async Task ThenTheCounterValueIs(int value)
        {
            var counterValue = await _counterPage.CounterValue();
            counterValue.Should().Be(value);
        }
    }
}