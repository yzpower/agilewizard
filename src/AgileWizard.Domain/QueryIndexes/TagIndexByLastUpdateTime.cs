using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class TagIndexByLastUpdateTime : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            var definition = new IndexDefinition<Tag>
            {
                Map = tags => from tag in tags
                              select new { LastUpdateTime = tag.LastUpdateTime },
            };

            return definition.ToIndexDefinition(DocumentStore.Conventions);

        }
    }
}
