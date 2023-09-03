using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bardakbots.module.bank.model
{
    [Table("BankAccount")]
    internal class BankAccount
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PK_Users")]
        public ulong UserId { get; set; }
        public double Bilance { get; set; } = 0;

        public BankAccount(ulong UserId) 
        {
            this.UserId = UserId;
            this.Bilance = Bilance;
        }

        public bool canAfford(double amount)
        {
            return this.Bilance < amount;
        }

        public void subtractMoney(double amount)
        {
            this.Bilance -= amount;
        }

        public void addMoney(double amount)
        {
            this.Bilance += amount;
        }
    }
}
