﻿using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.Data;
using Raven.Client.Document;
using TechTalk.SpecFlow;

namespace AgileWizard.AcceptanceTests
{
    [Binding]
    public class EventDefinition
    {
        [BeforeScenario]
        public void OpenBrowser()
        {
            BrowserHelper.OpenBrowser();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            BrowserHelper.CloseBrowser();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            documentStore.Initialize();

            var dataManager = new DataManager(documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //TODO: implement logic that has to run after the entire test run
        }
    }
}
