﻿using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.PageObject;
using TechTalk.SpecFlow;

namespace AgileWizard.AcceptanceTests.Steps
{
  
    [Binding]
    public class Resource
    {
        private ResoucePage _resourcePage;

        #region Add resource
        [Given(@"open adding-resource page")]
        public void GivenOpenAddingResourcePage()
        {
           ResoucePage.GoToCreate();
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)' and reference url - '(\b\w*://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|])' and tags - '(.+)'")]
        public void GivenEnterTitleAndContentAndAuthorAndReferenceUrlAndTags(string title, string content, string author, string refereneUrl, string tags)
        {
            _resourcePage = new ResoucePage(title, author, content, refereneUrl, tags);
        }

        [Given(@"enter title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)' and reference url - '(\b\w*://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|])'")]
        public void GivenEnterTitleAndContentAndAuthorAndReferenceUrl(string title, string content, string author, string refereneUrl)
        {
            _resourcePage = new ResoucePage(title, author, content, refereneUrl);
        }

        [When(@"press submit button")]
        public void WhenPressSubmitButton()
        {
            ResoucePage.Submit();
        }

        /// <summary>
        /// View resource detail
        /// </summary>
        [Then(@"resource details page should be shown")]
        public void ThenResourceDetailsPageShouldBeShown()
        {
            _resourcePage.AssertPage();
        }

        [Then(@"resource details page title with - '([\w\s]+)' should be shown")]
        public void ThenResourceDetailsPageTitleWithDetailTitleShouldBeShown(string title)
        {
            BrowserHelper.AssertPageTitle(title);
        }
        #endregion

        #region Adding Resource require login
        [Then("login page should be open")]
        public void AddResource_RequireLogin_RedirectToLoginPage()
        {
            AccountPage.AssertUrl();
        }

        #endregion

        #region Resource List
        [Given(@"open resource list page")]
        public void GivenOpenResourceListPage()
        {
            ResourceListPage.GoToPage();
        }

        [When(@"open a resource titled with '([\w\s]+)'")]
        public void ClickOnATitleOfAResource(string title)
        {
            ResourceListPage.GoToResourceDetail(title);
        }

        [Given(@"edit a resource titled with '([\w\s]+)'")]
        public void GivenEditAResource(string title)
        {
            ResourceListPage.GoToResourceEdit(title);
        }

        [Then(@"I can see the total resouce count")]
        public void ThenICanSeeTheTotalResouceCount()
        {
            ResourceListPage.AssertTotalResourceCount();
        }
        #endregion

        #region Resource List Culture
        [Then(@"resoure list page should be in current culture")]
        public void ThenICanSeeThePageinCurrentCulture()
        {
            ResourceListPage.AssertCulture();
        }
   
        #endregion

    }
}
