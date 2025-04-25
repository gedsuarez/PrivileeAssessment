using Microsoft.Playwright;
using PrivileeAssessment.Support.Pages;
using System.Drawing;

namespace PrivileeAssessment.Support.Utilities
{
    public class CommonUtilities(Hooks hooks, CommonObjects commonObjects)
    {
        private readonly IPage _page = hooks.Page;
        private readonly CommonObjects _commonObjects = commonObjects;

        public async Task GoTo(string url)
        {
            await _page.GotoAsync(url);
        }
        public async Task SubscribePrivileeUpdates(string firstName = null!, string mobileNumber = null!)
        {
            if (firstName == null)
            {
                firstName = CreateRandomString();
            }
            if (mobileNumber == null)
            {
                mobileNumber = CreateRandomNumber();
            }
            await _commonObjects.FirstName.FillAsync(firstName);
            await _commonObjects.Email.FillAsync(firstName + "@gmail.com");
            await _commonObjects.Mobile.FillAsync(mobileNumber);
            await _commonObjects.ViewButton.ClickAsync();
        }
        public static string CreateRandomString(int size = 10)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                Random rand = new Random();
                chars[i] = alphabet[rand.Next(alphabet.Length)];
            }

            var randomString = new string(chars);
            return randomString;
        }
        public static string CreateRandomNumber(long minSize = 1000000000, long maxSize = 9999999999)
        {
            Random rand = new Random();
            return rand.NextInt64(minSize, maxSize).ToString();
        }
    }
}
