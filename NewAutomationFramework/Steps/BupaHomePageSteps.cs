using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewAutomationFramework.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NewAutomationFramework.Steps
{
    [Binding]
    public class BupaHomePageSteps : BaseSteps
    {
        [Given(@"I am on '(.*)' page using '(.*)'")]
        public void GivenIAmOnPageUsing(string page, string browser)
        {
            try
            {
                if (driver is null)
                    driver = SetDriver(browser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Object obj = null;
            switch (page.ToLower())
            {               
                case "bupa":
                    driver.Url = "https://bupa.co.uk";
                    obj = new BupaHomePage(driver).Load();
                    ScenarioContext.Current["bupaHomePage"] = obj;
                    break;
                default:
                    break;
            }
        }

        [When(@"I click on Get a quote button")]
        public void WhenIClickOnGetAQuoteButton()
        {
            BupaHomePage bupaHomePage = (BupaHomePage)ScenarioContext.Current["bupaHomePage"];
            Assert.IsTrue(bupaHomePage.GetQuoteButton());
        }

        [Then(@"I should see cover option overlay")]
        public void ThenIShouldSeeCoverOptionOverlay()
        {
            BupaHomePage bupaHomePage = (BupaHomePage)ScenarioContext.Current["bupaHomePage"];
            Assert.IsTrue(bupaHomePage.VerifyOverLay());
        }
    }
}
