using Contacts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class ReportingRepositoryBase<T> : IReportingRepositoryBase<T> where T : class
    {
        protected OrderMateDbFinalContext RepositoryContext { get; set; }

        public ReportingRepositoryBase(OrderMateDbFinalContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T> GenerateReport(FormattableString expression)
        {
            return this.RepositoryContext.Set<T>().FromSqlInterpolated(expression).AsNoTracking();
        }
    }
}
