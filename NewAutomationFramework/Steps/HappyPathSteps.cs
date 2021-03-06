﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NewAutomationFramework.Steps
{
    [Binding]
    class HappyPathSteps
    {
        IWebDriver Driver;

        [Given(@"I am on Amazon India website")]
        public void GivenIAmOnAmazonIndiaWebsite()
        {
            Driver = new ChromeDriver(@"C:\Users\JK-WIN\source\repos\NewAutomationFramework\packages\Selenium.WebDriver.ChromeDriver.2.45.0\driver\win32");
            Driver.Url = "https://www.amazon.in";
            Driver.Manage().Window.Maximize();
            ScenarioContext.Current["Driver"] = Driver;
        }

        [When(@"I select Todays Deals")]
        public void WhenISelectTodaysDeals()
        {
            Driver = (IWebDriver)ScenarioContext.Current["Driver"];
            IWebElement lnkDeal = Driver.FindElement(By.XPath("//a[contains(text(),'Deal')]"));
            lnkDeal.Click();
        }

        [Then(@"I should see Todays Deals page")]
        public void ThenIShouldSeeTodaysDealsPage()
        {
            IWebElement lblDeal = Driver.FindElement(By.XPath("//div[@class='gbh1-bold']"));
            if (lblDeal.Displayed)
                Console.WriteLine("Page correctly displayed");
            else
                Console.WriteLine("Page is not displayed");
        }

        [When(@"I select first deal")]
        public void WhenISelectFirstDeal()
        {
            IWebElement lnkDeal1 = Driver.FindElement(By.XPath("//div[@class='a-row layer backGround']"));
            lnkDeal1.Click();
        }

        [Then(@"I should see related products")]
        public void ThenIShouldSeeRelatedProducts()
        {
            IWebElement lblDeal1 = Driver.FindElement(By.XPath("//a[@class='a - link - normal a - color - base a - text - bold a - text - normal']"));
            if (lblDeal1.Displayed)
                Console.WriteLine("Page correctly displayed");
            else
                Console.WriteLine("Page is not displayed");
        }

        

        [When(@"I select '(.*)' as departure city")]
        public void WhenISelectDepartureCity(string CityName)
        {
            IWebElement deparatureCity = Driver.FindElement(By.XPath("//input[@id='BE_flight_origin_city']"));
            deparatureCity.Clear();
            deparatureCity.Click();
            deparatureCity.SendKeys(CityName);
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Down);
            action.SendKeys(Keys.Enter);
            action.Perform();
        }

        [When(@"I select '(.*)' as destination city")]
        public void WhenISelectAsDestinationCity(string CityName)
        {
            IWebElement deparatureCity = Driver.FindElement(By.XPath("//input[@id='BE_flight_arrival_city']"));
            deparatureCity.Clear();
            deparatureCity.SendKeys(CityName);
        }

        [When(@"I Select '(.*)' & '(.*)'")]
        public void WhenISelect(string departDate, string returnDate)
        {
            string exactDate = Convert.ToDateTime(departDate).ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
            IWebElement txtdepartDateCal = Driver.FindElement(By.XPath("//input[@id='BE_flight_origin_date']"));
            txtdepartDateCal.Click();

            IWebElement txtdepartDate = Driver.FindElement(By.XPath("//td[@id='" + exactDate + "']"));
            txtdepartDate.Click();

            if (returnDate is "")
                Console.WriteLine("retun date is not avilable");
            else
            {
                string exactRetrunDate = Convert.ToDateTime(returnDate).ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);

                IWebElement txtreturnDateCal = Driver.FindElement(By.XPath("//input[@id='BE_flight_arrival_date']"));
                txtreturnDateCal.Click();

                IWebElement txtReturnDate = Driver.FindElement(By.XPath("//td[@id='" + exactRetrunDate + "']"));
                txtReturnDate.Click();
            }
        }

        [When(@"I select no of Travellers as '(.*)'")]
        public void WhenISelectNoOfTravellersAs(int p0)
        {

        }

        [When(@"I click on search")]
        public void WhenIClickOnSearch()
        {

        }

        [Then(@"I should see flight details")]
        public void ThenIShouldSeeFlightDetails()
        {

        }

        

        [When(@"I select '(.*)'")]
        public void WhenISelect(string Insurance)
        {
            IWebElement healthInsurance = Driver.FindElement(By.XPath("//a[@class='qtaBoxie border-white bg-cyan text-align-left']"));
            healthInsurance.Click();
        
        }

        [Then(@"I should see Pre-text condition overlay")]
        public void ThenIShouldSeePre_TextConditionOverlay()
        {
            IWebElement lblQuoteOverlay = Driver.FindElement(By.XPath("//div[@id='announcementBlue']"));
            if (lblQuoteOverlay.Displayed)
                Console.WriteLine("Overlay is displayed");
            else
                Console.WriteLine("Overlay is not displayed");

        }

        [When(@"I '(.*)' condition by clicking accept and continue button")]
        public void WhenIConditionByClickingAcceptAndContinueButton(string Acceptbutton)
        {
            IWebElement btnAccept = Driver.FindElement(By.XPath("//div[@class='btn BG_white FG_dark-blue href-analytics']"));
            btnAccept.Click();
            Thread.Sleep(3000);
        }

        [Then(@"I should see get a health quote page")]
        public void ThenIShouldSeeGetAHealthQuotePage()
        {
            IWebElement QuotePage = Driver.FindElement(By.XPath("//span[contains(text(),'Choose your cover')]"));
            if (QuotePage.Displayed)
                Console.WriteLine("Landed on quote page successfully");
            else
                Console.WriteLine("Landed on wrong page");
        }

        [When(@"I enter personal details as '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenIEnterPersonalDetailsAs(string FName, string LName, string Title, string DOB, string Gendar, string Occupation, string Smoke)
        {
            IWebElement ddlTitle = Driver.FindElement(By.XPath("//select[@id='TitleCode']"));
            SelectElement selectTitle = new SelectElement(ddlTitle);

            SelectElement select = new SelectElement(ddlTitle);
            select.SelectByText(Title);

            List<string> lstDOB = DOB.Split('/').ToList();
            IWebElement ddlDate = Driver.FindElement(By.XPath("//select[@id='DD']/option[contains(text(),'" + lstDOB.First() + "')]"));
            ddlDate.Click();

            IWebElement ddlMonth = Driver.FindElement(By.XPath("//select[@id='MM']/option[@value='" + lstDOB.ElementAt(1) + "']"));
            IWebElement ddlYear = Driver.FindElement(By.XPath("//select[@id='YY']/option[@value='" + lstDOB.Last() + "']"));

            IWebElement FirstName = Driver.FindElement(By.XPath("//input[@id='FirstName']"));
            FirstName.SendKeys(FName);

            IWebElement LastName = Driver.FindElement(By.XPath("//input[@id='LastName']"));
            LastName.SendKeys(LName);

            IWebElement QuoteGendar = Driver.FindElement(By.XPath("//span[@data-id='gender']"));
            QuoteGendar.SendKeys(Gendar);

            IWebElement QuoteOccupation = Driver.FindElement(By.XPath("//select[@id ='Occupation']"));
            SelectElement selectQOccupation = new SelectElement(QuoteOccupation);

       
            selectQOccupation.SelectByText(Occupation);

            IWebElement QSmoke = Driver.FindElement(By.XPath("//span[@data-id='DoYouSomke']"));
            QuoteGendar.SendKeys(Smoke);

            IWebElement btnContinue = Driver.FindElement(By.XPath("//div[@class='btn left-button BG_blue FG_white href-analytics']"));
            btnContinue.Click();


        }

        [When(@"I enter contact details as '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenIEnterContactDetailsAs(string Postcode, int PhoneNum, string Email, string QuoteDetails, int Startdate)
        {
           IWebElement AreaPostCode = Driver.FindElement(By.XPath("//input[@name='ContactDetails.Postcode']"));
            AreaPostCode.SendKeys(Postcode);

            IWebElement ContactNumber = Driver.FindElement(By.XPath("//input[@id='Telephone']"));
            ContactNumber.SendKeys(PhoneNum.ToString());

            IWebElement EmailAddress = Driver.FindElement(By.XPath("//input[@id='EmailAddress']"));
            EmailAddress.SendKeys(Email);

            IWebElement quoteSelection = Driver.FindElement(By.XPath("//span[@data-id='QuotePrefernce']"));
            quoteSelection.SendKeys(QuoteDetails);

            IWebElement PolicyStartDate = Driver.FindElement(By.XPath("//input[@id='PolicyStartDate']"));
            PolicyStartDate.Click();

            DateTime Effectivedate = DateTime.Today.AddDays(Startdate);

            IWebElement sdate = Driver.FindElement(By.XPath("//a[@class='ui-state-default'][contains(text(),'"+ Effectivedate.Day+"')]"));
            sdate.Click();

            IWebElement btnContinue = Driver.FindElement(By.XPath("//div[@class='btn left-button BG_blue FG_white href-analytics']"));
            btnContinue.Click();

        }

        [When(@"I select Additional family details as '(.*)','(.*)','(.*)'")]
        public void WhenISelectAdditionalFamilyDetailsAs(string FamilyMembers, string Relationship, string MemberDOB)
        {
            IWebElement btnfamily = Driver.FindElement(By.XPath("//a[@div = 'familySelectionBtn')][contains(text(),'" + FamilyMembers + "')]"));
            btnfamily.Click();

            IWebElement Relation = Driver.FindElement(By.XPath("//select[@class=show-tooltip member-relationship"));
            SelectElement FamilyRelation = new SelectElement(Relation);

            List<string> DOBofMember = MemberDOB.Split('/').ToList();

            DateTime mdate = DateTime.Now.AddYears(Convert.ToInt32("-"+ DOBofMember[0]));


            IWebElement mDate = Driver.FindElement(By.XPath("//select[@id='dependenthide_DD111'][contains(text(),'" + mdate.Day + "')]"));
            mDate.Click();

            IWebElement mMonth = Driver.FindElement(By.XPath("//select[@id='dependenthide_MM111'][contains(@value,'" + mdate.Month + "')]"));
            mMonth.Click();

            IWebElement mYear = Driver.FindElement(By.XPath("//select[@id='partnerhide_YY111'][contains(@value,'" + mdate.Year + "')]"));
            mYear.Click();

            try
            {
                IWebElement smokevalidation = Driver.FindElement(By.XPath("//span[@data-id='DoYouSomke']"));
                smokevalidation.Click();

            }
            catch (Exception)
            {

              
            }


               







        }

     

        [When(@"I click on choose your cover button")]
        public void WhenIClickOnChooseYourCoverButton()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
