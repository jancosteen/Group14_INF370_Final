using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class QrCodeRepository: RepositoryBase<QrCode>, IQrCodeRepository
    {
        public QrCodeRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateQrCode(QrCode qrCode)
        {
            Create(qrCode);
        }

        public void DeleteQrCode(QrCode qrCode)
        {
            Delete(qrCode);
        }

        public IEnumerable<QrCode> GetAllQrCodes()
        {
            return FindAll()
                .OrderBy(q => q.RestaurantIdFk)
                .ToList();
        }

        public QrCode GetQrCodeById(int qrCodeId)
        {
            return FindByCondition(q => q.QrCodeId.Equals(qrCodeId))
                .FirstOrDefault();
        }

        public QrCode GetQrCodeWithDetails(int qrCodeId)
        {
            return FindByCondition(q => q.QrCodeId.Equals(qrCodeId))
                .Include(q => q.RestaurantIdFkNavigation)
                .Include(q => q.QrCodeSeating)
                .FirstOrDefault();
        }

        public void UpdateQrCode(QrCode qrCode)
        {
            Update(qrCode);
        }
    }
}
