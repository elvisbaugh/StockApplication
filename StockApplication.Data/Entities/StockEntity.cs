using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockApplication.Data.Entities
{
    public class StockEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockId {get; set;}
        public string StockSymbol {get; set;}
        public decimal StockPrice {get; set;}
        public decimal StockShares { get; set;}
        public int BrokerId { get; set;}
        public DateTime StockDate {get; set;}
    }
}
