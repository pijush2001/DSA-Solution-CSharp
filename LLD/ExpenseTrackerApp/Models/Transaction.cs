using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {  get; set; }

        //categoryId
        public int CategoryId {  get; set; }

        //navigational property
        public Category Category { get; set; }
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }
        public DateTime Date {  get; set; } = DateTime.Now;
    }
}
