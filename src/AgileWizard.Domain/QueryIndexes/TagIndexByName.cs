using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.QueryIndexes
{
    public class TagIndexByName : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<Tag>
            {
                Map = tags => from tag in tags
                              select new { Name = tag.Name.ToLower() }
            }
            .ToIndexDefinition(DocumentStore.Conventions);
        }
    }
}
