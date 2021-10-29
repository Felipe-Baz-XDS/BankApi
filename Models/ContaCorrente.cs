using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class ContaCorrente
    {
        [Key]
        public int Id { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Data { get; set; }
    }
}
