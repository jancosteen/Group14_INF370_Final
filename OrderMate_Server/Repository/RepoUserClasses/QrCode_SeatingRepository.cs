using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class QrCode_SeatingRepository: RepositoryBase<QrCodeSeating>, IQrCode_SeatingRepository
    {
        public QrCode_SeatingRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateQrCodeSeating(QrCodeSeating qrCodeSeating)
        {
            Create(qrCodeSeating);
        }

        public void DeleteQrCodeSeating(QrCodeSeating qrCodeSeating)
        {
            Delete(qrCodeSeating);
        }

        public IEnumerable<QrCodeSeating> GetAllQrCodeSeatings()
        {
            return FindAll()
                .OrderBy(q => q.SeatingIdFk)
                .ToList();
        }

        public QrCodeSeating GetQrCodeSeatingById(int qrCodeId, int seatingId)
        {
            return FindByCondition(q => q.QrCodeIdFk.Equals(qrCodeId) && q.SeatingIdFk.Equals(seatingId))
                .FirstOrDefault();
        }

        public QrCodeSeating GetQrCodeSeatingWithDetails(int qrCodeId, int seatingId)
        {
            return FindByCondition(q => q.QrCodeIdFk.Equals(qrCodeId) && q.SeatingIdFk.Equals(seatingId))
                .Include(q => q.OrderIdFkNavigation)
                .Include(q => q.QrCodeIdFkNavigation)
                .Include(q => q.SeatingIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateQrCodeSeating(QrCodeSeating qrCodeSeating)
        {
            Update(qrCodeSeating);        
        }
    }
}
