using FluentAssertions;
using NUnit.Framework;
using PlaywrightSpecflowV2.Drivers;
using PlaywrightSpecflowV2.Pages;
using System.Globalization;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightSpecflowV2.Steps
{
    [Binding]
    public sealed class FetchDataSteps
    {
        private readonly Driver _driver;
        private readonly FetchDataPage _fetchDataPage;

        public FetchDataSteps(Driver driver)
        {
            _driver = driver;
            _fetchDataPage = new FetchDataPage(_driver.Page);
        }

        [Given("the user is on the Fetch Data page")]
        public async Task GivenTheUserIsOnTheFetchDataPage()
        {
            await _driver.Page.GotoAsync(_fetchDataPage.PagePath);
        }

        [When("the page loads")]
        public async Task WhenThePageLoads()
        {
            // auto-wait feature of playwright should perform this step
        }

        [Then(@"the user should be able to see a table with the following columns:")]
        public async Task ThenTheUserShouldBeAbleToSeeATableWithTheFollowingColumns(Table table)
        {
            var actualHeaders = new List<string>
            {
                await _fetchDataPage.DateColumnValue(),
                await _fetchDataPage.TempCColumnValue(),
                await _fetchDataPage.TempFColumnValue(),
                await _fetchDataPage.SummaryColumnValue(),
            };

            var expectedHeaders = table.Header;

            actualHeaders.Should().BeEquivalentTo(expectedHeaders);
        }

        [Then(@"the table should contain the following weather forecasts:")]
        public async Task ThenTheTableShouldContainTheFollowingWeatherForecasts(Table table)
        {
            var actualForecasts = await PopulateActualWeatherForecasts();

            var expectedForecasts = await PopulateExpectedWeatherForecasts(table);

            actualForecasts[0].Should().BeEquivalentTo(expectedForecasts[0]);
            actualForecasts[1].Should().BeEquivalentTo(expectedForecasts[1]);
            actualForecasts[2].Should().BeEquivalentTo(expectedForecasts[2]);
            actualForecasts[3].Should().BeEquivalentTo(expectedForecasts[3]);
            actualForecasts[4].Should().BeEquivalentTo(expectedForecasts[4]);
        }

        private async Task<List<WeatherForecast>> PopulateExpectedWeatherForecasts(Table table)
        {
            var forecasts = new List<WeatherForecast>();

            foreach (var row in table.Rows)
            {
                var forecast = new WeatherForecast
                {
                    Date = DateOnly.Parse(row["Date"]),
                    TemperatureC = int.Parse(row["Temp. (C)"]),
                    TemperatureF = int.Parse(row["Temp. (F)"]),
                    Summary = row["Summary"]
                };

                forecasts.Add(forecast);
            }

            return forecasts;
        }

        private async Task<List<WeatherForecast>> PopulateActualWeatherForecasts()
        {
            var forecasts = new List<WeatherForecast>();

            for (int i = 0; i < 5; i++)
            {
                var date = await _fetchDataPage.GetDateForRow(i);
                var tempC = await _fetchDataPage.GetTempCForRow(i);
                var tempF = await _fetchDataPage.GetTempFForRow(i);
                var summary = await _fetchDataPage.GetSummaryForRow(i);

                var forecast = new WeatherForecast
                {
                    Date = date,
                    TemperatureC = tempC,
                    TemperatureF = tempF,
                    Summary = summary
                };

                forecasts.Add(forecast);
            }

            return forecasts;
        }
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
    public string Summary { get; set; }
}