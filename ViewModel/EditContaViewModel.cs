using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.ViewModel
{
    public class EditContaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="O campo Agencia é obrigatorio.")]
        public int Agencia { get; set; }
        [Required(ErrorMessage="O campo Numero é obrigatorio.")]
        public int Numero { get; set; }
        [Required(ErrorMessage="O campo Titular é obrigatorio.")]
        [MinLength(3, ErrorMessage ="O campo Titular não pode conter menos de 3 caracteres")]
        public string Titular { get; set; }
        public decimal Saldo { get; set; }
    }
}