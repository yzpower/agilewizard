﻿using System;
using System.Collections.Generic;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        private IResourceRepository _repository;

        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public Resource AddResource(string title, string content, string author, string submitUser)
        {
            var resource = _repository.Add(title, content, author, submitUser);
            _repository.Save();
            return resource;
        }

        public Resource GetResourceById(string id)
        {
            return _repository.GetResourceById(id);
        }

        public IList<Resource> GetResourceList()
        {
            return _repository.GetResourceList();
        }

        public int GetResourcesTotalCount()
        {
            return _repository.GetResourcesTotalCount();
        }

        public void UpdateResource(string id, Resource resource)
        {
            var resourceUpdate = _repository.GetResourceById(id);
            resourceUpdate.Title = resource.Title;
            resourceUpdate.Content = resource.Content;
            resourceUpdate.LastUpdateTime = DateTime.Now;
            _repository.Save();

        }
    }
}