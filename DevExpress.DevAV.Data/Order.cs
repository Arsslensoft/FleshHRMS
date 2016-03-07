using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace DevExpress.DevAV {
    public enum OrderShipMethod {
        Ground,
        Air
    }
    public class Order : DatabaseObject {
        public Order() {
            OrderItems = new List<OrderItem>();
        }
        public string InvoiceNumber { get; set; }
        public virtual Customer Customer { get; set; }
        public long? CustomerId { get; set; }
        public virtual CustomerStore Store { get; set; }
        public long? StoreId { get; set; }
        public string PONumber { get; set; }
        public virtual Employee Employee { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal SaleAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal ShippingAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderShipMethod ShipMethod { get; set; }
        public string OrderTerms { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
