using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Allergy
    {
        public Allergy()
        {
            MenuItemAllergy = new HashSet<MenuItemAllergy>();
        }

        public int AllergyId { get; set; }
        public string Allergy1 { get; set; }

        public virtual ICollection<MenuItemAllergy> MenuItemAllergy { get; set; }
    }
}
