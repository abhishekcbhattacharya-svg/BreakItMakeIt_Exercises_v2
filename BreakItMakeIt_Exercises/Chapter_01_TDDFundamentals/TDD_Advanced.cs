using Microsoft.Playwright;

namespace BreakItMakeIt_Exercises;

public class TDD_Advanced
{
    private IBrowser _browser;
    private IPage _page;
    private IPlaywright _playwright;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // Set to true for headless mode
        });

        var context = await _browser.NewContextAsync();
        _page = await context.NewPageAsync();
    }

    [Test]
    public async Task SearchTDDOnline()
    {
        //Arrange - SetUp
        //Act - multiple steps
        //Validate, interact using _page

        //Steps
        //Go to google
        //search TDD
        //Read first search result

        // Assert
        Assert.Fail();
    }

    [TearDown]
    public async Task Teardown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}