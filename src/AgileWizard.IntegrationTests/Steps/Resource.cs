﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Repositories;
using AgileWizard.IntegrationTests.PageObject;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using StructureMap;
using TechTalk.SpecFlow;
using Xunit;
using AgileWizard.Website.Helper;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using AgileWizard.Domain.Models;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class ResourceSteps
    {
        private const string SubmitUser = "agilewizard";
        private const string ACTION_RESULT_KEY = "ActionResult";
        private const string EXISTING_RESOURCE_KEY = "ExistingResource";
        private const string SUBMITTED_RESOURCE_MODEL_KEY = "SubmittedResourceModel";
        private const string PENDING_SUBMITTED_RESOURCE_MODEL_KEY = "PendingSubmittedResourceModel";

        [Given(@"new resource with  title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)' and tags - '(.+)'")]
        public void GivenNewResourceWithTitleContentAuthorAndTags(string title, string content, string author, string tags)
        {
            var resourceModel = new ResourceModel
                                 {
                                     Tags = tags,
                                     Title = title,
                                     Author = author,
                                     Content = content,
                                     SubmitUser = SubmitUser
                                 };
            CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] = resourceModel;
        }

        [Given(@"reference url - '(\b\w*://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|])'")]
        public void GivenRefereceUrl(string referenceUrl)
        {
            var resourceModel = CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] as ResourceModel;
            resourceModel.ReferenceUrl = referenceUrl;
        }



        [Then(@"display the title, content, author and submit user and tags")]
        public void ThenDisplayDetailInformation()
        {
            var actionResult = CurrentScenario[ACTION_RESULT_KEY] as RedirectToRouteResult;
            var resourceRepository = ObjectFactory.GetInstance<IResourceRepository>();
            var resourceId = actionResult.RouteValues["id"].ToString();
            var actualResource = resourceRepository.GetResourceById(resourceId);
            var submittedResourceModel = CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] as ResourceModel;

            Assert.Equal(actualResource.Title, submittedResourceModel.Title);
            Assert.Equal(actualResource.Content, submittedResourceModel.Content);
            Assert.Equal(actualResource.Author, submittedResourceModel.Author);
            Assert.Equal(actualResource.SubmitUser, SubmitUser);
            Assert.Equal(actualResource.ReferenceUrl, submittedResourceModel.ReferenceUrl);
            Assert.Equal(actualResource.Tags.Count, submittedResourceModel.Tags.ToTagList().Count);
        }

        [Given(@"there is a resource")]
        public void GivenThereIsAResource(Table table)
        {
            var resource = table.CreateInstance<Resource>();
            foreach (var row in table.Rows)
            {
                if (row["Field"] == "Tags")
                {
                    resource.Tags = row["Value"].Split(',').Select(s => new Resource.ResourceTag() { Name = s }).ToList();
                }
            }
            var repository = ObjectFactory.GetInstance<IResourceRepository>();
            resource = repository.Add(resource);
            repository.Save();
            CurrentScenario[EXISTING_RESOURCE_KEY] = resource;
        }

        [When(@"modify the resource")]
        public void WhenModifyTheResource(Table table)
        {
            var resourceModel = table.CreateInstance<ResourceModel>();
            var resource = CurrentScenario[EXISTING_RESOURCE_KEY] as Resource;
            var id = resource.Id.Substring(10);
            var controller = ObjectFactory.GetInstance<ResourceController>();
            var actionResult = controller.Edit(id, resourceModel);
            CurrentScenario[SUBMITTED_RESOURCE_MODEL_KEY] = resourceModel;
            CurrentScenario[ACTION_RESULT_KEY] = actionResult;
        }

        [Then(@"navigate to edit page")]
        public void ThenNavigateToEditPage()
        {
            var actionResult = CurrentScenario[ACTION_RESULT_KEY] as ViewResult;
            Assert.Empty(actionResult.ViewName);
        }

        [Then(@"show edit for the title, content, author and tags")]
        public void ThenShowEditForTheTitleContentAuthorAndTags()
        {
            var actionResult = CurrentScenario[ACTION_RESULT_KEY] as ViewResult;
            var resourceRepository = ObjectFactory.GetInstance<IResourceRepository>();
            var actualResource = actionResult.ViewData.Model as ResourceModel;
            var existingResource = CurrentScenario[EXISTING_RESOURCE_KEY] as Domain.Models.Resource;

            Assert.Equal(actualResource.Title, existingResource.Title);
            Assert.Equal(actualResource.Author, existingResource.Author);
            Assert.Equal(actualResource.Content, existingResource.Content);
            Assert.Equal(actualResource.ReferenceUrl, existingResource.ReferenceUrl);
            Assert.Equal(actualResource.Tags.ToTagList().Count, existingResource.Tags.Count);
        }

        [When(@"open the resource to edit")]
        public void WhenOpenTheResourceToEdit()
        {
            var controller = ObjectFactory.GetInstance<ResourceController>();
            var resource = CurrentScenario[EXISTING_RESOURCE_KEY] as Domain.Models.Resource;
            var id = resource.Id.Substring(10);
            var actionResult = controller.Edit(id);
            CurrentScenario[ACTION_RESULT_KEY] = actionResult;
        }

        [Given(@"new resource with  title - (.+) and content - (.+) and author - (.+) and tags - (.+) and reference url - (\b\w*://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|])")]
        public void GivenNewResourceWithTitleAndContentAndAuthorAndTagsAndReferenceUrl(string title, string content, string author, string tags, string referenceurl)
        {
            var resourceModel = new ResourceModel
                            {
                                Tags = tags,
                                Title = title,
                                Author = author,
                                Content = content,
                                ReferenceUrl = referenceurl,
                            };

            CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] = resourceModel;
        }

        [When(@"submit resource to system")]
        public void WhenSubmitResourceToSystem()
        {
            CreateResource();
        }

        [Then(@"navigate to details page")]
        public void ThenNavigateToDetailsPage()
        {
            var resourceDetail = new ResourceDetail();
            var actionResult = CurrentScenario[ACTION_RESULT_KEY];
            resourceDetail.AssertAction(actionResult as RedirectToRouteResult);
        }

        private void CreateResource()
        {
            var resourceController = ObjectFactory.GetInstance<ResourceController>();
            var pendingSubmittedResourceModel = CurrentScenario[PENDING_SUBMITTED_RESOURCE_MODEL_KEY] as ResourceModel;

            CurrentScenario[ACTION_RESULT_KEY] = resourceController.Create(pendingSubmittedResourceModel);
        }

        private ScenarioContext CurrentScenario 
        {
            get 
            {
                return ScenarioContext.Current; 
            } 
        }
    }
}
