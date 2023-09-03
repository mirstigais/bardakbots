using Bardakbots.module.bank.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bardakbots.Models
{
    [Table("Users")]
    internal class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ulong Id { get; set; }

        public string Username { get; set; } = null;

        public BankAccount BankAccount { get; set; }

        public User(ulong Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
            BankAccount = new BankAccount(Id);
        }
    }
}
