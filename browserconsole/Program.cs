using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace browserconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string USERNAME = "soniamathew_GUgiVQ";
            string AUTOMATE_KEY = "5r5YCzZ1XNjmWNB2zVxH";

            OpenQA.Selenium.Chrome.ChromeOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();

            // for Firefox
            // OpenQA.Selenium.Firefox.FirefoxOptions capability = new OpenQA.Selenium.Firefox.FirefoxOptions();

            // for Safari
            // OpenQA.Selenium.Safari.SafariOptions capability = new OpenQA.Selenium.Safari.SafariOptions();

            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("userName", USERNAME);
            browserstackOptions.Add("accessKey", AUTOMATE_KEY);
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("projectName", "Sample Amazon project");
            browserstackOptions.Add("buildName", "Build #1");
            browserstackOptions.Add("sessionName", "My First Test");
            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            IWebDriver driver;
            driver = new RemoteWebDriver(
              new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capabilities
            );
            //driver.Navigate().GoToUrl("http://www.google.com");

            // Your test script like you usually write
            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.amazon.in/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.in%2F%3Fref_%3Dnav_ya_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=inflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&");
            Thread.Sleep(2000);

            //identify the email id text box  
            IWebElement ele = driver.FindElement(By.Id("ap_email"));
            //enter the mail id value 
            ele.SendKeys("soniya.suntec1@gmail.com");
            ele.Submit();
            Console.Write("\n Username is entered");

            Thread.Sleep(2000);

            

            //identify the password text box  
            IWebElement ele1 = driver.FindElement(By.Id("ap_password"));
            //enter the password value  
            ele1.SendKeys("######");
            Console.Write("\n Password is entered \n ");

            Console.WriteLine(driver.Title);



            // Setting the status of test as 'passed' or 'failed' based on the condition; if title of the web page matches 'BrowserStack - Google Search'
            string str = "Amazon Sign In";
            if (string.Equals(driver.Title, str))
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Title matched!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Title not matched \"}}");
            }
            driver.Quit();

        }
    }
}
