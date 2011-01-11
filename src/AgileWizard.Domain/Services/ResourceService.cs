using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        private IResourceRepository _repository;

        private ITagRepository _tagRepository;

        public ResourceService(IResourceRepository repository, ITagRepository tagRepository)
        {
            _repository = repository;
            _tagRepository = tagRepository;
        }

        public Resource AddResource(Resource source)
        {
            var resource = _repository.Add(source);

            _tagRepository.AddOrUpdateTagList(source.Id, source.Tags);
            
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

            var existingTags = resourceUpdate.Tags;

            resourceUpdate.Title = resource.Title;
            resourceUpdate.Content = resource.Content;
            resourceUpdate.LastUpdateTime = DateTime.Now;
            resourceUpdate.Author = resource.Author;
            resourceUpdate.SubmitUser = resource.SubmitUser;
            resourceUpdate.ReferenceUrl = resource.ReferenceUrl;
            resourceUpdate.Tags = resource.Tags;

            _tagRepository.RemoveTagList(resourceUpdate.Id, existingTags);
            _tagRepository.AddOrUpdateTagList(resourceUpdate.Id, resource.Tags);
            
            _repository.Save();

        }
    }
}