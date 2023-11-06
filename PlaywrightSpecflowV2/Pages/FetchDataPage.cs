using Microsoft.Playwright;

namespace PlaywrightSpecflowV2.Pages
{
    public class FetchDataPage
    {
        public string PagePath => "http://localhost:5201/fetchData";

        private readonly IPage _page;
        private readonly ILocator _dateColumnHeader;
        private readonly ILocator _tempCColumnHeader;
        private readonly ILocator _tempFColumnHeader;
        private readonly ILocator _summaryColumnHeader;

        public FetchDataPage(IPage page)
        {
            _page = page;
            _dateColumnHeader = _page.GetByRole(AriaRole.Cell, new() { Name = "Date" });
            _tempCColumnHeader = _page.GetByRole(AriaRole.Cell, new() { Name = "Temp. (C)" });
            _tempFColumnHeader = _page.GetByRole(AriaRole.Cell, new() { Name = "Temp. (F)" });
            _summaryColumnHeader = _page.GetByRole(AriaRole.Cell, new() { Name = "Summary" });
        }

        public async Task<string> DateColumnValue() => await _dateColumnHeader.InnerTextAsync();
        public async Task<string> TempCColumnValue() => await _tempCColumnHeader.InnerTextAsync();
        public async Task<string> TempFColumnValue() => await _tempFColumnHeader.InnerTextAsync();
        public async Task<string> SummaryColumnValue() => await _summaryColumnHeader.InnerTextAsync();

        public async Task<DateOnly> GetDateForRow(int rowIndex)
        {
            var row = _page.Locator("table tbody tr").Nth(rowIndex);
            var dateCell = row.Locator("td:nth-child(1)");
            return DateOnly.Parse(await dateCell.InnerTextAsync());
        }

        public async Task<int> GetTempCForRow(int rowIndex)
        {
            var row = _page.Locator("table tbody tr").Nth(rowIndex);
            var tempCCell = row.Locator("td:nth-child(2)");
            return int.Parse(await tempCCell.InnerTextAsync());
        }

        public async Task<int> GetTempFForRow(int rowIndex)
        {
            var row = _page.Locator("table tbody tr").Nth(rowIndex);
            var tempFCell = row.Locator("td:nth-child(3)");
            return int.Parse(await tempFCell.InnerTextAsync());
        }

        public async Task<string> GetSummaryForRow(int rowIndex)
        {
            var row = _page.Locator("table tbody tr").Nth(rowIndex);
            var summaryCell = row.Locator("td:nth-child(4)");
            return await summaryCell.InnerTextAsync();
        }
    }
}
