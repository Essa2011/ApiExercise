//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnythingDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockItemTransaction
    {
        public int StockItemTransactionID { get; set; }
        public int StockItemID { get; set; }
        public int TransactionTypeID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> PurchaseOrderID { get; set; }
        public System.DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual StockItem StockItem { get; set; }
    }
}
