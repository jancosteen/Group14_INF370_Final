using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IQrCodeRepository: IRepositoryBase<QrCode>
    {
        IEnumerable<QrCode> GetAllQrCodes();
        QrCode GetQrCodeById(int qrCodeId);
        QrCode GetQrCodeWithDetails(int qrCodeId);
        void CreateQrCode(QrCode qrCode);
        void UpdateQrCode(QrCode qrCode);
        void DeleteQrCode(QrCode qrCode);
    }
}
