using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using BoDi;
using OpenQA.Selenium.Support.Extensions;
using SeFramework.Context.General;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SeFramework.Hooks.GeneralHook
{
    [Binding]
    class SpecFlowHooks
    {
        private readonly ExecutionContext executionContext;
        private static string ReportDirectory;
        public static string ReportPath;
        private static ExtentReports extent;
        private static ExtentTest featureName;
        private static ExtentTest scenario;

        public SpecFlowHooks(IObjectContainer container)
        {
            executionContext = new ExecutionContext()
            {
                ConfigReader = InitialisationActions.GetConfigReader()
            };
            container.RegisterInstanceAs(executionContext);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "Report\\";
            ReportPath = ReportDirectory + "index.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.ReportName = "TTC BDD";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            executionContext.Driver = InitialisationActions.InitialiseDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            executionContext.Driver?.Close();
            executionContext.Driver?.Quit();
            executionContext.Driver?.Dispose();
            executionContext.Driver = null;
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {

            var stepInfo = scenarioContext.StepContext.StepInfo;
            var stepStatus = scenarioContext.ScenarioExecutionStatus;
            ExtentTest test;
            switch (stepInfo.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    test = scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.When:
                    test = scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.Then:
                    test = scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                default:
                    test = scenario.CreateNode("default");
                    break;
            }

            if (stepStatus != ScenarioExecutionStatus.OK)
            {
                var screenshot = executionContext.Driver.TakeScreenshot().AsBase64EncodedString;
                test.Fail(string.Format("Error from: {0}<br>Error Details: {1}",
                    scenarioContext.TestError.Source,
                    scenarioContext.TestError.Message),
                    MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
                test.CreateNode("Stacktrace:");
                test.Debug(scenarioContext.TestError.StackTrace);
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

    }
}
