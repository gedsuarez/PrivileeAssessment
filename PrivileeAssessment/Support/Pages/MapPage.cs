using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PrivileeAssessment.Support.Utilities;

namespace PrivileeAssessment.Support.Pages
{
    public class MapPage(Hooks hooks)
    {
        private readonly IPage _page = hooks.Page;
        public ILocator VenueTypeHeader => _page.Locator("h3.bbFeEY");
        public ILocator VenueHeader => _page.Locator("h2.kvdDpe");
        public ILocator SearchBox => _page.Locator("input[placeholder*='Search']");
        public ILocator FilterButton => _page.GetByText("Filters");
        public ILocator DisplayedVenueLocation => _page.Locator(".efePEY");
        public ILocator SearchList => _page.Locator("ul.kHWhtf");
        public ILocator OpeningHours => _page.Locator("span.cwssDb");
        public ILocator VenueDescription => _page.Locator("div.cUZXHm p");
        public ILocator AnnualMembersTag => _page.Locator("div.jwShUC");
        public ILocator AnnualMembersTick => _page.Locator("div.ecOrNM");
        public ILocator AnnualMembersLabel => _page.Locator("div.fBoyQT span");
        public ILocator AnnualMembersLockOverlay => _page.Locator("svg.cHylbc");
        public ILocator NoResultMessage => _page.Locator("div.kdVOJD div");
        public string venue = null!;
        public string FilterLocation = null!;

    }
}

