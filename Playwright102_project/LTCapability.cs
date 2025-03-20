using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System;

namespace Playwright102_project
{
    public class LTCapability
    {
        [DatapointSource]
        public static object[] GetDefaultTestCapability()
        {
            // First capability
            JObject capabilities1 = new JObject();
            JObject ltOptions1 = new JObject();
            string user = "username";
            string accessKey = "accesskey";

            capabilities1["browserName"] = "Chrome";
            capabilities1["browserVersion"] = "latest";
            ltOptions1["platform"] = "Windows 10";
            ltOptions1["name"] = "Playwright Test";
            ltOptions1["build"] = "Playwright102 certification-hyperexecute";
            ltOptions1["user"] = "pratibha_jamdare";
            ltOptions1["accessKey"] = "LT_km9Px0t0c89vVuJwd07eqIfXfbQ6hnSum4NJs9y5XaqEatN";
            ltOptions1["video"] = true;
            capabilities1["LT:Options"] = ltOptions1;

            // Second capability
            JObject capabilities2 = new JObject();
            JObject ltOptions2 = new JObject();

            capabilities2["browserName"] = "MicrosoftEdge"; // Browsers allowed: Chrome, MicrosoftEdge, pw-chromium, pw-firefox, pw-webkit
            capabilities2["browserVersion"] = "latest";
            ltOptions2["platform"] = "Windows 10";
            ltOptions2["name"] = "Playwright Test";
            ltOptions2["build"] = "Playwright102 certification-hyperexecute";
            ltOptions2["user"] = user;
            ltOptions2["accessKey"] = accessKey;
            capabilities2["LT:Options"] = ltOptions2;

            return new object[] { capabilities1, capabilities2 };
        }

        private static string GetBrowserName()
        {
            string browserName = null;

            // Check for common environment variables
            if (Environment.GetEnvironmentVariable("BROWSER") != null)
            {
                browserName = Environment.GetEnvironmentVariable("BROWSER");
            }
            else if (Environment.GetEnvironmentVariable("BROWSER_NAME") != null)
            {
                browserName = Environment.GetEnvironmentVariable("BROWSER_NAME");
            }
            else if (Environment.GetEnvironmentVariable("PLAYWRIGHT_CHROMIUM") != null)
            {
                browserName = "Chrome";
            }
            else if (Environment.GetEnvironmentVariable("PLAYWRIGHT_FIREFOX") != null)
            {
                browserName = "Firefox";
            }
            else if (Environment.GetEnvironmentVariable("PLAYWRIGHT_WEBKIT") != null)
            {
                browserName = "webkit";
            }
            else if (Environment.GetEnvironmentVariable("PLAYWRIGHT_EDGE") != null)
            {
                browserName = "Edge";
            }
            else if (TestContext.Parameters.Get("browser", null) != null)
            {
                browserName = TestContext.Parameters.Get("browser");
            }
            else
            {
                Console.Error.WriteLine("Error: Browser information not found in environment variables or system properties.");
                Environment.Exit(1);
            }

            return browserName;
        }
    }
}
