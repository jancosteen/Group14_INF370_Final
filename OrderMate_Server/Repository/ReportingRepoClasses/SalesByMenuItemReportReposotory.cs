using Contacts.IReports;
using Entities.Models;
using Entities.Reporting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.ReportingRepoClasses
{
    public class SalesByMenuItemReportReposotory :  ISalesByMenuITemRepository //ReportingRepositoryBase<SalesByMenuItemReport>,
    {
        protected OrderMateDbDel08Context RepositoryContext { get; set; }

        public SalesByMenuItemReportReposotory(OrderMateDbDel08Context repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
       

        public IQueryable<SalesByMenuItemReport> GenerateReport(FormattableString expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesByMenuItemReport> GetSalesByMenuItem(int menuItemId, DateTime Datefrom, DateTime DateTo)
        {
            throw new NotImplementedException();
        }
    }
}
