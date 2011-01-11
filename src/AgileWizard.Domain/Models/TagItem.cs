using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileWizard.Domain.Models
{
    public class TagItem
    {
        public string Id { get; set; }

        public int ItemType { get; set; }

        public string TagId { get; set; }

        public string ItemId { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public enum TagItemType
        {
            Resource = 0,
        }
    }
}
