using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Infrastructure;

namespace TestScenario.StepDefinitions
{
    [Binding]
    public sealed class TestPageStepDefinitions
    {
        private IWebDriver driver;

        public TestPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Open browser")]
        public void GivenOpenBrowser()
        {
            //driver = new ChromeDriver();
        }

        [When(@"Navigate to URL")]
        public void WhenNavigateToURL()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Url = "https://the-internet.herokuapp.com/add_remove_elements/";
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='content']")));
        }

        [Then(@"Add '([^']*)' elements")]
        public void ThenAddElements(string s)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            var addElementButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@onclick='addElement()']")));

            int n = Int32.Parse(s);
            for (int i = 0; i < n; i++)
            {
                addElementButton.Click();
            }
        }

        [Then(@"Assert that '([^']*)' number of elements exist on the page")]
        public void ThenAssertThatNumberOfElementsExistOnThePage(string s)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            var elements = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='elements']")));
            string childsCount = elements.GetAttribute("childElementCount");
            
            Assert.AreEqual(s, childsCount);
        }

    }
}
