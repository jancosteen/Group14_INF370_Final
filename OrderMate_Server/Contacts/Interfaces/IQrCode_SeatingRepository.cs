using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IQrCode_SeatingRepository: IRepositoryBase<QrCodeSeating>
    {
        IEnumerable<QrCodeSeating> GetAllQrCodeSeatings();
        QrCodeSeating GetQrCodeSeatingById(int qrCodeId, int seatingId);
        QrCodeSeating GetQrCodeSeatingWithDetails(int qrCodeId, int seatingId);
        void CreateQrCodeSeating(QrCodeSeating qrCodeSeating);
        void UpdateQrCodeSeating(QrCodeSeating qrCodeSeating);
        void DeleteQrCodeSeating(QrCodeSeating qrCodeSeating);
    }
}
