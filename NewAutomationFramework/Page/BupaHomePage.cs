using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAutomationFramework.Page
{
   public class BupaHomePage : LoadableComponent<BupaHomePage> 
    {
        readonly IWebDriver driver;
        bool isPageLoaded;

        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Bupa 2019')]")]
        IWebElement lnkBupa { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nudge']//a[@class=' btn-white-box qte_btnInsideNudge btn_quote ']")]
        IWebElement btngetQuote { get; set; }

        public BupaHomePage(IWebDriver d)
        {
            driver = d;
            PageFactory.InitElements(driver, this);
        }

        
        protected override bool EvaluateLoadedStatus()
        {
            if(lnkBupa.Displayed)
            {
                log.Info("Page is loaded correctly");
                isPageLoaded = true;
            }
            else
            {
                log.Error("Page is not loaded correctly");
            }
            return isPageLoaded;
        }

        protected override void ExecuteLoad()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(10);
        }

        public bool GetQuoteButton()
        {
            bool result = false;
            log.Debug("Started verifing get quote button");
            try
            {
                if (btngetQuote.Displayed)
                {
                    btngetQuote.Click();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if(ex is NoSuchElementException)
                {
                    log.Error("Get quote button not found");
                    log.Info("button found due to error" + ex.Message);
                    throw ex;
                }
                
            }
                    
            return result;
        }

        public bool VerifyOverLay()
        {
            bool result = false;
            IWebElement lbloverlay = driver.FindElement(By.XPath("//div[@class='overlay-quote-box bg-cyan']"));
            if (lbloverlay.Displayed)
            {
                Console.WriteLine("Overlay is displayed");
                result = true;
            }               
            else
                Console.WriteLine("Overlay is not displayed");

            return result; 
        }
    }
}
