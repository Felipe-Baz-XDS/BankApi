using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public DateTime Data { get; set; }
    }
}
