using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;
using Raven.Client;
using AgileWizard.Domain.QueryIndexes;

namespace AgileWizard.Domain.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IDocumentSession _documentSession;

        public TagRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        #region Tag

        public Tag GetTagById(int id)
        {
            return _documentSession.Load<Tag>(string.Format("{0}", id));
        }

        public Tag AddTag(Tag tag)
        {
            var document = new Tag
            {
                Name = tag.Name,
                LastUpdateTime = DateTime.Now,
            };

            _documentSession.Store(document);

            return document;
        }

        private Tag GetTagByName(string name)
        {
            var query = _documentSession.Query<Tag>(typeof(TagIndexByName).Name);

            return query.FirstOrDefault(x => x.Name == name.ToLower());
        }

        public void RemoveTagList(string resourceId, List<Resource.ResourceTag> tagList)
        {
            foreach (var x in tagList)
            {
                var tagItem = GetTagItemByTagId_ThenByItemId_ThenByItemType(x.Id, resourceId, (int)AgileWizard.Domain.Models.TagItem.TagItemType.Resource);

                if (tagItem != null)
                {
                    _documentSession.Delete<TagItem>(tagItem);
                }
            }
        }

        public void AddOrUpdateTagList(string resourceId, List<Resource.ResourceTag> tagList)
        {
            foreach (var x in tagList)
            {
                var tag = AddOrUpdateTag(x);

                this.AddOrUpdateTagItem(new TagItem
                {
                    TagId = tag.Id,
                    ItemId = resourceId,
                    ItemType = (int)TagItem.TagItemType.Resource,
                });
            }
        }

        private Tag AddOrUpdateTag(Resource.ResourceTag x)
        {
            var tag = this.GetTagByName(x.Name);
            if (tag == null)
            {
                tag = this.AddTag(new Tag { Name = x.Name });
            }
            else
            {
                tag.LastUpdateTime = DateTime.Now;
            }

            x.Id = tag.Id;
            return tag;
        }

        public List<Tag> GetTagList(int maxCount)
        {
            var query = _documentSession.Query<Tag>(typeof(TagIndexByLastUpdateTime).Name);

            return query.Take(maxCount).ToList();
            
        }

        #endregion


        #region TagItem


        private TagItem AddTagItem(TagItem tagItem)
        {
            var document = new TagItem
            {
                TagId = tagItem.TagId,
                ItemId = tagItem.ItemId,
                ItemType = tagItem.ItemType,
                LastUpdateTime = DateTime.Now,
            };

            _documentSession.Store(document);

            return document;
        }

        private TagItem AddOrUpdateTagItem(TagItem tagItem)
        {
            var document = GetTagItemByTagId_ThenByItemId_ThenByItemType(tagItem.TagId, tagItem.ItemId, tagItem.ItemType);

            if (document == null)
            {
                document = this.AddTagItem(new TagItem
                {
                    TagId = tagItem.TagId,
                    ItemId = tagItem.ItemId,
                    ItemType = tagItem.ItemType,
                });
            }
            else
            {
                document.LastUpdateTime = DateTime.Now;
            }

            return document;
        }

        private TagItem GetTagItemByTagId_ThenByItemId_ThenByItemType(string tagId, string itemId, int itemType)
        {
            var query = _documentSession.Query<TagItem>(typeof(TagItemIndexByTagIdThenByItemId).Name);

            return query.FirstOrDefault(x => x.TagId == tagId && x.ItemId == itemId && x.ItemType == itemType);
        }

        #endregion

    }
}
