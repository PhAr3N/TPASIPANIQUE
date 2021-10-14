using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp3.Models.DataManager;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

namespace tp3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        //readonly CompteManager _compteManager;
        private readonly IDataRepository<Compte> _dataRepository;
        public CompteController(IDataRepository<Compte> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public CompteController(CompteManager compteManager)
        {
            _dataRepository = compteManager;
        }

        // GET: api/Compte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
        {
            return await _dataRepository.GetAll();
        }

        // GET: api/Compte/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compte))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = await _dataRepository.GetById(id);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        [HttpGet("{email}")]
        [ActionName("getByMail")]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email) {

            var compte = await _dataRepository.GetByString(email);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;

        }

        // PUT: api/Compte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }
            var compteToUpdate = await _dataRepository.GetById(id);
            if (compteToUpdate == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(compteToUpdate.Value, compte);
            return NoContent();
        }

        // POST: api/Compte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            await _dataRepository.Add(compte);

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            var compte = await _dataRepository.GetById(id);
            if (compte == null)
            {
                return NotFound();
            }

            await _dataRepository.Delete(compte.Value);

            return NoContent();
        }
    }
}
