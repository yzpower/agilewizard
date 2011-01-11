using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Services
{
    public class ResourceServiceTest
    {
        private const string ID = "1";
        private const string DOCUMENT_ID = "resources/1";
        private const string TITLE = "title";
        private const string CONTENT = "content";
        private const string AUTHOR = "author";
        private const string SUBMITUSER = "submituser";

        private Mock<IResourceRepository> _resourceRepository;
        private Mock<ITagRepository> _tagRepository;
        private IResourceService _service;

        private readonly DateTime _prepareTime = DateTime.Now.AddSeconds(-1);
        private Resource _resource = new Resource()
                                                  {
                                                      Id = DOCUMENT_ID,
                                                      Title = TITLE,
                                                      Content = CONTENT,
                                                      Author = AUTHOR,
                                                      SubmitUser = SUBMITUSER
                                                  };

        public ResourceServiceTest()
        {
            _resourceRepository = new Mock<IResourceRepository>();
            _tagRepository = new Mock<ITagRepository>();

            _service = new ResourceService(_resourceRepository.Object, _tagRepository.Object);

            _resource.CreateTime = _prepareTime;
            _resource.LastUpdateTime = _prepareTime;
        }

        [Fact]
        public void Can_add_resource()
        {
            var source = new Resource();
            //Arrange
            _resourceRepository.Setup(r => r.Add(source)).Returns(_resource).Verifiable();
            _resourceRepository.Setup(r => r.Save()).Verifiable();

            //Act
            var resource = _service.AddResource(source);

            //Assert
            _resourceRepository.VerifyAll();
            Assert.Equal(_resource, resource);
        }

        [Fact]
        public void Given_an_id_should_return_a_resource()
        {
            //Arrange
            _resourceRepository.Setup(r => r.GetResourceById(ID)).Verifiable();

            //Act
            _service.GetResourceById(ID);

            //Assert
            _resourceRepository.VerifyAll();
        }

        [Fact]
        public void Can_get_a_list_of_resources()
        {
            //Arrange
            var expectedResources = new List<Resource>();
            _resourceRepository.Setup(r => r.GetResourceList()).Returns(expectedResources);

            //Act
            var actualResources = _service.GetResourceList();

            //Assert
            Assert.Equal(expectedResources, actualResources);
        }

        [Fact]
        public void Can_update_resource()
        {
            //Arrange
            var resourceToUpdate = new Resource() { Title = "Title to update", Content = "Content to update" };
            _resourceRepository.Setup(r => r.GetResourceById(ID)).Returns(_resource);
            _resourceRepository.Setup(r => r.Save()).Verifiable();

            //Act
            _service.UpdateResource(ID, resourceToUpdate);

            //Assert
            _resourceRepository.VerifyAll();
            ResourceShouldBeUpdated(_resource, resourceToUpdate);
        }

        private void ResourceShouldBeUpdated(Resource resource, Resource resourceToUpdate)
        {
            Assert.Equal(resourceToUpdate.Title, resource.Title);
            Assert.Equal(resourceToUpdate.Content, resource.Content);
            Assert.Equal(_prepareTime, resource.CreateTime);
            Assert.True(resource.LastUpdateTime > _prepareTime);
        }
    }
}
