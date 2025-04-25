using Microsoft.Playwright;
using PrivileeAssessment.Support.Utilities;

namespace PrivileeAssessment.Support.Pages
{
    public class CommonObjects(Hooks hooks)
    {
        private readonly IPage _page = hooks.Page;
        public ILocator FirstName => _page.Locator("[name='first_name']");
        public ILocator Email => _page.Locator("[name='email']");
        public ILocator Mobile => _page.Locator("[name='mobile']");
        public ILocator ViewButton => _page.Locator("button.sc-b8700080-0");
    }
}
