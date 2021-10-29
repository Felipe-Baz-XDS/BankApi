
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Data;
using BankApi.Models;
using BankApi.Services;
using BankApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly appDbContext _context;
        //private readonly UserService _userService;

        public AuthController(appDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary="Mostra a Lista de Users")]  
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            var user = await _context
                .Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(user);
        }


        [HttpGet]
        [SwaggerOperation(Summary="Mostra um User escolhido pelo ID")]  
        [Route("{id}")]
        public async Task<IActionResult> GetAsyncById(
            [FromRoute] int id
        )
        {
            var user = await _context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);            

            if(user == null)
                return BadRequest();
            return Ok(user);
        }


        [HttpPost]
        [SwaggerOperation(Summary="Adiciona um User")]  
        [Route("")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateUserViewModel model
        )
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var user = new User{
                Username = model.Username,
                Senha = model.Senha,
                Cargo = model.Cargo,
                Cpf = model.Cpf,
                Cep = model.Cep,
                Data = DateTime.Now,
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created(uri:"v1/Auth/{user.Id}", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary="Edita User")]  
        [Route("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] CreateUserViewModel model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
                return BadRequest();

            try
            { 
                user.Username = model.Username;
                user.Senha = model.Senha;
                user.Cargo = model.Cargo;
                user.Cpf = model.Cpf;
                user.Cep = model.Cep;
                user.Data = DateTime.Now;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [SwaggerOperation(Summary="Deleta User")]  
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id
        )
        {
            var user = await _context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            try
            {
                _context.Users.Remove(user);
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