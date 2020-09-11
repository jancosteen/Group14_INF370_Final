using Entities.Reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.IReports
{
    public interface ISalesByMenuITemRepository: IReportingRepositoryBase<SalesByMenuItemReport>
    {
        IEnumerable<SalesByMenuItemReport> GetSalesByMenuItem(int menuItemId, DateTime Datefrom, DateTime DateTo);
    }
}
