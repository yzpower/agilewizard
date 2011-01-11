using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class TagItemIndexByTagIdThenByItemId : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<TagItem>
            {
                Map = tagItems => from tagItem in tagItems
                                  select new
                                  {
                                      TagId = tagItem.TagId,
                                      ItemId = tagItem.ItemId,
                                      ItemType = tagItem.ItemType,
                                  },
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }
    }
}
