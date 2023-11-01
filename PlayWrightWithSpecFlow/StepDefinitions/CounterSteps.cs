using FluentAssertions;
using PlaywrightBlazorSample.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace PlayWrightWithSpecFlow.StepDefinitions
{
    [Binding]
    public class CounterSteps
    {
        private readonly CounterPageObject _counterPageObject;

        public CounterSteps(CounterPageObject counterPageObject)
        {
            _counterPageObject = counterPageObject;
        }

        [Given(@"a user in the counter page")]
        public async Task GivenAUserInTheCounterPage()
        {
            await _counterPageObject.NavigateAsync();
        }

        [When(@"the increase button is clicked (.*) times")]
        public async Task WhenTheIncreaseButtonIsClickedTimes(int times)
        {
            for (var i = 0; i < times; i++)
            {
                await _counterPageObject.ClickIncreaseButton();
            }
        }

        [Then(@"the counter value is (.*)")]
        public async Task ThenTheCounterValueIs(int value)
        {
            var counterValue = await _counterPageObject.CounterValue();
            counterValue.Should().Be(value);
        }
    }
}