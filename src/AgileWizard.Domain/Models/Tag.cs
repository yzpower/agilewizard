using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileWizard.Domain.Models
{
    public class Tag
    {
        public string Id { get; set; }

        //public int TotalCount { get; set; }

        //public string CssClass { get; set; }

        public string Name { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
