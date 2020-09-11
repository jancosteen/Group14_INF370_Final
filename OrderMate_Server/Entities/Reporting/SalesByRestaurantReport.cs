using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Reporting
{
    public class SalesByRestaurantReport
    {
        public int Menu_Item_Id { get; set; }
        public string Menu_Item_Name { get; set; }
        public double Menu_Item_Price {get;set;}
        public DateTime Order_Date_Completed { get; set; }
        public int Restaurant_Id { get; set; }
    }
}
