using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Reporting
{
    public class SupplierOrderReport
    {
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public DateTime Supplier_Order_Date { get; set; }
        public string Product_Name { get; set; }
        public double Product_Standard_Price { get; set; }
        public int Ordered_Qty { get; set; }
        public int Delivery_Lead_Time { get; set; }
        public double Discount_Agreement { get; set; }
    }
}
