using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuItemAllergy
    {
        public int MenuItemIdFk { get; set; }
        public int AllergyIdFk { get; set; }
        public int MenuItemAllergyId { get; set; }

        public virtual Allergy AllergyIdFkNavigation { get; set; }
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
    }
}
