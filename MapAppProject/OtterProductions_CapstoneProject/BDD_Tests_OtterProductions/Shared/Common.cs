using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Tests_OtterProductions.Shared
{
    // Sitewide definitions and useful methods
    public class Common
    {
        public const string BaseUrl = "https://localhost:7196";     // copied from launchSettings.json
        

        // File to store browser cookies in
        public const string CookieFile = "..\\..\\..\\..\\..\\..\\..\\StandupsCookies.txt";

        // Page names that everyone should use
        // A handy way to look these up
        public static readonly Dictionary<string, string> Paths = new()
        {
            { "Home" , "/" },
            { "Login", "/Identity/Account/Login" },
            { "Register", "/Identity/Account/Register" },
            { "Registration", "/Identity/Account/Register" },
            { "Map", "/Map/Mappage"},
            { "Privacy", "/Home/Privacy"},
            { "FAQ", "/Home/FAQ"},
            { "Events Search", "/Home/BrowsingSearch"},
            {"EventInfo", "/Home/EventPage/24"},
            {"EditInfo", "/Users/EditInfo" },
            {"EditLogin", "/Identity/Account/Login?ReturnUrl=%2FUsers%2FEditInfo" }
            {"EventInfo", "/Home/EventPage/24"},
            { "SearchEvent", "/Home/BrowsingSearch"},
        };

        public static string PathFor(string pathName) => Paths[pathName];
        public static string UrlFor(string pathName) => BaseUrl + Paths[pathName];
    }
}
