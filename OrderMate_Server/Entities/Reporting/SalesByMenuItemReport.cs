using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Reporting
{
    //[Keyless]
    public class SalesByMenuItemReport
    {
        public int Menu_Item_Id { get; set; }
        public string Menu_Item_Name { get; set; }
        public double Menu_Item_Price { get; set; }
        public DateTime Order_Date_Created { get; set; }
    }
}
