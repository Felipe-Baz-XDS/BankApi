using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage="O campo Username é obrigatorio.")]
        [MinLength(3, ErrorMessage ="O campo Username não pode conter menos de 3 caracteres")]
        public string Username { get; set; }
        
        [Required(ErrorMessage="O campo Senha é obrigatorio.")]
        [MinLength(3, ErrorMessage ="O campo Senha não pode conter menos de 3 caracteres")]
        public string Senha { get; set; }

        
        [Required(ErrorMessage="O campo Cargo é obrigatorio.")]
        [MinLength(3, ErrorMessage ="O campo Cargo não pode conter menos de 3 caracteres")]
        public string Cargo { get; set; }
        [Required(ErrorMessage="O campo Cargo é obrigatorio.")]
        [MinLength(11, ErrorMessage ="O campo CPF aceita somente 11 caracteres no minimo")]
        [MaxLength(14, ErrorMessage ="O campo CPF aceita somente 14 caracteres no maximo")]
        public string Cpf { get; set; }
        public string Cep { get; set; }
    }
}