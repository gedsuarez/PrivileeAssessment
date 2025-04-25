using System;
using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PrivileeAssessment.Support.Pages;
using PrivileeAssessment.Support.Utilities;
using Reqnroll;

namespace PrivileeAssessment.StepDefinitions
{
    [Binding]
    public class MapStepDefinitions(Hooks hooks, CommonUtilities commonUtilities, CommonObjects commonObjects, MapPage map) : PageTest
    {
        private readonly IPage _page = hooks.Page;
        private readonly CommonUtilities _commonUtilities = commonUtilities;
        private readonly CommonObjects _commonObjects = commonObjects;
        private readonly MapPage _map = map;
        private readonly string mapUrl = Environment.GetEnvironmentVariable("MAP_URL");

        [Given("the user opens the browser")]
        public void GivenTheUserOpensTheBrowser()
        {
        }

        [Given("the user proceeds to Privilee map website")]
        public async Task GivenTheUserProceedsToPrivileeMapWebsite()
        {
            await _commonUtilities.GoTo(mapUrl);
        }

        [When("the user clicks on {string}")]
        public async Task WhenTheUserClicksOn(string venue)
        {
            _map.venue = venue;
            await _page.Locator($"[alt*='{venue}']").First.ClickAsync();
        }

        [Then("the user should see the venue is correct")]
        public async Task ThenTheUserShouldSeeTheVenueIsCorrect()
        {
            if (await _commonObjects.FirstName.IsEnabledAsync())
            {
                await _commonUtilities.SubscribePrivileeUpdates();
            }
            await Expect(_map.VenueHeader).ToHaveTextAsync(_map.venue);
            await Expect(_map.OpeningHours).Not.ToBeEmptyAsync();
            await Expect(_map.VenueDescription.First).Not.ToBeEmptyAsync();
        }

        [When("the user searches {string}")]
        public async Task WhenTheUserSearches(string venue)
        {
            _map.venue = venue;
            await _map.SearchBox.FillAsync(venue);
            await _map.SearchBox.PressAsync("Enter");
        }

        [When("the user filters {string} as location")]
        public async Task WhenTheUserFiltersAsLocation(string location)
        {
            _map.FilterLocation = location;
            await _map.FilterButton.First.ClickAsync();
            await _page.Locator($"span:text-is('{location}')").ClickAsync();
            await _page.Locator(".jygJwH").ClickAsync();
        }

        [Then("the user should see venues with the filtered locations")]
        public async Task ThenTheUserShouldSeeVenuesWithTheFilteredLocations()
        {
            var venueLocationCount = await _map.DisplayedVenueLocation.CountAsync();
            for (int i = 0; i < venueLocationCount; i++)
            {
                await Expect(_map.DisplayedVenueLocation.Nth(i)).ToContainTextAsync(_map.FilterLocation);
            }
        }

        [Given("the user clicks the {string} button")]
        public async Task GivenTheUserClicksTheButton(string venueType)
        {
            await _page.Locator($"button:text-is('{venueType}')").ClickAsync();
        }

        [When("the user clicks the {string} button")]
        public async Task WhenTheUserClicksTheButton(string venueType)
        {
            await _page.Locator($"button:text-is('{venueType}')").ClickAsync();
        }

        [Then("the user should see no results found")]
        public async Task ThenTheUserShouldSeeNoResultsFound()
        {
            await Expect(_map.SearchList).ToHaveTextAsync("No Results Found");
        }

        [Then("the user should see a message indicating that it is an annual member only venue")]
        public async Task ThenTheUserShouldSeeAMessageIndicatingThatItIsAnAnnualMemberOnlyVenue()
        {
            await Expect(_map.AnnualMembersTag).ToHaveTextAsync("Annual members only");
        }

        [Then("the user should see a lock overlay when venue is for annual members only")]
        public async Task ThenTheUserShouldSeeALockOverlayWhenVenueIsForAnnualMembersOnly()
        {
            int totalAnnualMembersOnlyVenue = await _map.AnnualMembersLabel.CountAsync();
            for (int i = 0; i < totalAnnualMembersOnlyVenue; i++)
            {
                await Expect(_map.AnnualMembersLockOverlay.Nth(i)).ToBeVisibleAsync();
            }
        }

        [When("the user ticks the Annual members only button")]
        public async Task WhenTheUserTicksTheAnnualMembersOnlyButton()
        {
            await _map.AnnualMembersTick.ClickAsync();
        }

        [Then("the user should not see a lock overlay when venue is for annual members only")]
        public async Task ThenTheUserShouldNotSeeALockOverlayWhenVenueIsForAnnualMembersOnly()
        {
            int totalAnnualMembersOnlyVenue = await _map.AnnualMembersLabel.CountAsync();
            for (int i = 0; i < totalAnnualMembersOnlyVenue; i++)
            {
                await Expect(_map.AnnualMembersLockOverlay.Nth(i)).Not.ToBeVisibleAsync();
            }
        }

        [When("the user clicks on {string} filters")]
        public async Task WhenTheUserClicksOnFilters(string filters)
        {
            string[] allFilters = filters.Split(';');
            await _map.FilterButton.First.ClickAsync();
            foreach (var filter in allFilters)
            {
                await _page.Locator($"button:has-text('{filter}')").ClickAsync();
            }
            await _page.Locator(".jygJwH").ClickAsync();
        }

        [Then("the user should that there are no venues matching the selected filters")]
        public async Task ThenTheUserShouldThatThereAreNoVenuesMatchingTheSelectedFilters()
        {
            await Expect(_map.VenueTypeHeader).ToContainTextAsync("0");
            await Expect(_map.NoResultMessage).ToHaveTextAsync("Sorry, there are no venues matching your search and filters.");
        }

    }
}
