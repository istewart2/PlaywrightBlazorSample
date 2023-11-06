using FluentAssertions;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PlaywrightSpecflowV2.Drivers;
using PlaywrightSpecflowV2.Pages;
using System;
using TechTalk.SpecFlow;

namespace PlaywrightSpecflowV2.Steps
{
    [Binding]
    public sealed class MultipleTasksSteps
    {
        private readonly Driver _driver;
        private readonly FetchDataPage _fetchDataPage;

        public MultipleTasksSteps(Driver driver)
        {
            _driver = driver;
            _fetchDataPage = new FetchDataPage(_driver.Page);
        }

        [Given(@"the user wants to validate Playwrights performance")]
        public void GivenTheUserWantsToValidatePlaywrightsPerformance()
        {
            // empty
        }

        [When(@"they take lots of different actions")]
        public async Task WhenTheyTakeLotsOfDifferentActionsAsync()
        {
            // not a good test, just doing lots of actions to check performance
            await _driver.Page.GotoAsync(_fetchDataPage.PagePath);

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync(new LocatorClickOptions
            {
                ClickCount = 100,
            });

            var counterLocator = _driver.Page.Locator("#counter-val");
            var counterValue = int.Parse(await counterLocator.InnerTextAsync());
            counterValue.Should().Be(100);

            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync(new LocatorClickOptions
            {
                ClickCount = 100,
            });

            var counterLocator2 = _driver.Page.Locator("#counter-val");
            var counterValue2 = int.Parse(await counterLocator2.InnerTextAsync());
            counterValue2.Should().Be(200);

            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync(new LocatorClickOptions
            {
                ClickCount = 100,
            });

            var counterLocator3 = _driver.Page.Locator("#counter-val");
            var counterValue3 = int.Parse(await counterLocator3.InnerTextAsync());
            counterValue3.Should().Be(300);

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Fetch data" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "06/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "1", Exact = true }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "33" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Freezing" }).First.ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "07/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "14" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "57" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Bracing" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "08/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "-13" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "9", Exact = true }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Freezing" }).Nth(1).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "09/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "-16" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "4", Exact = true }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Balmy" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "10/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "-2" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "29" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Chilly" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync(new LocatorClickOptions
            {
                ClickCount = 100,
            });

            var counterLocator4 = _driver.Page.Locator("#counter-val");
            var counterValue4 = int.Parse(await counterLocator4.InnerTextAsync());
            counterValue4.Should().Be(100);

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Fetch data" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "06/05/2018" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "1", Exact = true }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "33" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Cell, new() { Name = "Freezing" }).First.ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync(new LocatorClickOptions
            {
                ClickCount = 100,
            });

            var counterLocator5 = _driver.Page.Locator("#counter-val");
            var counterValue5 = int.Parse(await counterLocator5.InnerTextAsync());
            counterValue5.Should().Be(100);

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Home" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Heading, new() { Name = "Hello, world!" }).ClickAsync();

            await _driver.Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();
        }

        [Then(@"they can confirm that execution time is low")]
        public void ThenTheyCanConfirmThatExecutionTimeIsLow()
        {
            // empty
        }

    }
}
