using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp3.Models.EntityFramework;
using tp3.Models.Repository;

namespace tp3.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {
        readonly tp3Context _context;
        public CompteManager(tp3Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Compte>>> GetAll()
        {
            return await _context.Comptes.ToListAsync();
        }
        public async Task<ActionResult<Compte>> GetById(int id)
        {
            return await _context.Comptes.FirstOrDefaultAsync(e => e.CompteId == id);
        }
        public async Task<ActionResult<Compte>> GetByString(string mail)
        {
            return await _context.Comptes.FirstOrDefaultAsync(e => e.Mel.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Compte entity)
        {
             await _context.Comptes.AddAsync(entity);
             await _context.SaveChangesAsync();
        }
        public async Task Update(Compte compte, Compte entity)
        {
            _context.Entry(compte).State = EntityState.Modified;
            compte.CompteId = entity.CompteId;
            compte.Nom = entity.Nom;
            compte.Prenom = entity.Prenom;
            compte.Mel = entity.Mel;
            compte.Rue = entity.Rue;
            compte.CodePostal = entity.CodePostal;
            compte.Ville = entity.Ville;
            compte.Pays = entity.Pays;
            compte.Latitude = entity.Latitude;
            compte.Longitude = entity.Longitude;
            compte.Pwd = entity.Pwd;
            compte.TelPortable = entity.TelPortable;
            compte.FavorisCompte = entity.FavorisCompte;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Compte compte)
        {
            _context.Comptes.Remove(compte);
            await _context.SaveChangesAsync();
        }
    }
}
