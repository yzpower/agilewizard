using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Services
{
    public class ResourceServiceTest
    {
        private Mock<IResourceRepository> _repository;
        private IResourceService _service;

        public ResourceServiceTest()
        {
            _repository = new Mock<IResourceRepository>();
            _service = new ResourceService(_repository.Object);
        }

        [Fact]
        public void Can_add_resource()
        {
            //Arrange
            const string TITLE = "title";
            const string CONTENT = "content";
            _repository.Setup(r => r.Add(TITLE, CONTENT)).Verifiable();
            
            //Act
            _service.AddResource(TITLE, CONTENT);
            
            //Assert
            _repository.VerifyAll();
        }

        [Fact]
        public void Given_an_id_should_return_a_resource()
        {
            //Arrange
            const string ID = "1";
            _repository.Setup(r => r.GetResourceById(ID)).Verifiable();
            
            //Act
            _service.GetResourceById(ID);
            
            //Assert
            _repository.VerifyAll();
        }

        [Fact]
        public void Can_get_a_list_of_resources()
        {
            //Arrange
            var expectedResources = new List<Resource>();
            _repository.Setup(r => r.GetResourceList()).Returns(expectedResources);

            //Act
            var actualResources = _service.GetResourceList();

            //Assert
            Assert.Equal(expectedResources, actualResources);

        }
    }
}