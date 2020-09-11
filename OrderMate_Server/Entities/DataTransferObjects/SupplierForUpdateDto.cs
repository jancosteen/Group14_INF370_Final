using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SupplierForUpdateDto
    {
        [Required(ErrorMessage = "Supplier Name is required")]
        [StringLength(50, ErrorMessage = "Supplier Name can't be longer than 50 characters")]
        public string SupplierName { get; set; }

        [StringLength(200, ErrorMessage = "Supplier Name can't be longer than 50 characters")]
        public string SupplierDescription { get; set; }
        [Required(ErrorMessage = "Supplier Email is required")]
        [StringLength(50, ErrorMessage = "Supplier Email can't be longer than 50 characters")]
        public string SupplierEmail { get; set; }
        [Required(ErrorMessage = "Supplier Contact Number is required")]
        [StringLength(10, ErrorMessage = "Supplier Contact Number can't be longer than 10 characters")]
        public string SupplierContactNumber { get; set; }
        [Required(ErrorMessage = "Supplier Address is required")]
        [StringLength(50, ErrorMessage = "Supplier Address Line 1 can't be longer than 200 characters")]
        public string SupplierAddressLine1 { get; set; }
        [StringLength(50, ErrorMessage = "Supplier Address Line 2 can't be longer than 200 characters")]
        public string SupplierAddressLine2 { get; set; }
        [StringLength(50, ErrorMessage = "Supplier Address Line 3 can't be longer than 200 characters")]
        public string SupplierAddressLine3 { get; set; }
        [Required(ErrorMessage = "Supplier City is required")]
        [StringLength(50, ErrorMessage = "Supplier City can't be longer than 50 characters")]
        public string SupplierCity { get; set; }
        [StringLength(50, ErrorMessage = "Supplier Postal code can't be longer than 5 characters")]
        public string SupplierPostalCode { get; set; }
        [Required(ErrorMessage = "Supplier Country is required")]
        [StringLength(50, ErrorMessage = "Supplier Country can't be longer than 50 characters")]
        public string SupplierCountry { get; set; }
    }
}
