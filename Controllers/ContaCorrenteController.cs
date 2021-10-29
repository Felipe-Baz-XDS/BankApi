using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Data;
using BankApi.Models;
using BankApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly appDbContext _context;
        //private readonly UserService _userService;

        public ContaCorrenteController(appDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary="Mostra a Lista de Contas")]  
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            var contas = await _context
                .Contas
                .AsNoTracking()
                .ToListAsync();
            return Ok(contas);
        }

        [HttpGet]
        [SwaggerOperation(Summary="Mostra um User escolhido pelo ID")]  
        [Route("{id}")]
        public async Task<IActionResult> GetAsyncById(
            [FromRoute] int id
        )
        {
            var conta = await _context
                .Contas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);            

            if(conta == null)
                return BadRequest();

            return Ok(conta);
        }

        [HttpPost]
        [SwaggerOperation(Summary="Adiciona uma Conta")]  
        [Route("")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateContaViewModel model
        )
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var conta = new ContaCorrente{
                Agencia = model.Agencia,
                Numero = model.Numero,
                Titular = model.Titular,
                Saldo = 0m,
                Data = DateTime.Now,

            };

            try
            {
                await _context.Contas.AddAsync(conta);
                await _context.SaveChangesAsync();
                return Created(uri:"v1/Auth/{conta.Id}", conta);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary="Edita Conta")]  
        [Route("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditContaViewModel model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var conta = await _context
                .Contas
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (conta == null)
                return BadRequest();

            try
            { 
                conta.Agencia = model.Agencia;
                conta.Numero = model.Numero;
                conta.Titular = model.Titular;
                conta.Saldo = model.Saldo;
                conta.Data = DateTime.Now;

                _context.Contas.Update(conta);
                await _context.SaveChangesAsync();
                return Ok(conta);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [SwaggerOperation(Summary="Deleta Conta")]  
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id
        )
        {
            var conta = await _context
                .Contas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            try
            {
                _context.Contas.Remove(conta);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}