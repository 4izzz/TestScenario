﻿using BoDi;
using LivingDoc.Dtos;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _container = container;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");

            IWebDriver driver = new ChromeDriver(options);

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver();
            if (driver is ITakesScreenshot screenshotDriver)
            {
                var filename = Path.Combine("screenshots", Path.ChangeExtension(Path.GetRandomFileName(), "png")); // Save in "screenshots" directory

                // Capture and save the screenshot
                var screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
                
                // Attach the screenshot to the scenario
                _specFlowOutputHelper.AddAttachment(filename, "Screenshot");
            }
        }
    }
}