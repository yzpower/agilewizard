using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Repositories
{
    public interface ITagRepository
    {
        Tag GetTagById(int id);

        void RemoveTagList(string resourceId, List<Resource.ResourceTag> tagList);

        void AddOrUpdateTagList(string resourceId, List<AgileWizard.Domain.Models.Resource.ResourceTag> tagList);

        List<Tag> GetTagList(int maxCount);
    }
}
