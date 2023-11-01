using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vendor.DataEntities.Models
{
    public class Vendors :IdentityUser
    {
        [Key]
        public int VendorID { get; set; }
        public string? VendorName { get; set; }
        public string? ContactInfo { get; set; }
        public bool VerificationStatus { get; set; }
        public string? VendorLocation { get; set; }
        public string? VendorType { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        // Other properties specific to vendors

        public virtual ICollection<VendorProductsTable> Products { get; set; }
        public virtual ICollection<VendorNotificationTable> Notifications { get; set; }
    }

    public class VendorProductsTable
    {
        [Key]
        public int ProductID { get; set; }
        public int VendorID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        // Other properties specific to products

        public virtual Vendors Vendor { get; set; }
        public virtual ICollection<VendorProductCategoryTable> ProductCategories { get; set; }
        // Other navigation properties
    }

    public class VendorCategoriesTable
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        // Other properties specific to categories

        public virtual ICollection<VendorProductCategoryTable> ProductCategories { get; set; }
    }

    public class VendorProductCategoryTable
    {
        [Key]
        public int ProductCategoryId { get;set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public virtual VendorProductsTable Product { get; set; }
        public virtual VendorCategoriesTable Category { get; set; }
    }

    public class VendorOrderTable
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        // Other properties specific to orders

        public virtual ICollection<VendorOrderItemTable> OrderItems { get; set; }
    }

    public class VendorOrderItemTable
    {
        [Key]
        public int OrderItemID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public virtual VendorOrderTable Order { get; set; }
        public virtual VendorProductsTable Product { get; set; }
    }

    public class VendorNotificationTable
    {
        [Key]
        public int NotificationID { get; set; }
        public int VendorID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        // Other properties specific to notifications

        public virtual Vendors Vendor { get; set; }
    }
}