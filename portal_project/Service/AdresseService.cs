using portal_project.Exceptions;
using portal_project.Metier;
using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Service
{
   public class AdresseService
    {
        private IAdresse dao;

        public AdresseService(IAdresse dao)
        {
            this.dao = dao;
        }

        public void createAdress(Adresse adresse)
        {
            Adresse adresseDb = dao.findOneByCoordinates(adresse.Axe_X, adresse.Axe_Y);
            if (adresseDb == null || (adresse.Axe_X == 0 && adresse.Axe_Y == 0))
            {
                dao.createAdress(adresse);
            }
            else
            {
                throw new AlreadyCreatedException("L'adresse que vous essayer de créer existe déjà");
            }
        }

        public void deleteAdresse(int id_adresse)
        {
            Adresse adresseDB = dao.findOneById(id_adresse);
            if (adresseDB != null)
            {
                dao.deleteAdresse(id_adresse);
            }
            else
            {
                throw new NotFoundException("L'adresse avec l'id " + id_adresse + " n'existe pas");
            }
        }

        public void editAdress(Adresse adresse)
        {
            Adresse adresseDB = dao.findOneById(adresse.Id);
            if (adresseDB != null)
            {
                dao.editAdress(adresse);
            }
            else
            {
                throw new NotFoundException("L'adresse avec l'id " + adresse.Id + " n'existe pas");
            }
        }

        public List<Adresse> findByCodePostal(string code_postal)
        {
            List<Adresse> adresses= dao.findByCodePostal(code_postal);
            if (adresses.Count > 0)
            {
                return adresses;
            }
            else
            {
             throw new ListEmptyException("Aucune adresse ne correspond avec le code postal "+code_postal);
            }
        }

        public List<Adresse> findByVille(string ville)
        {
            List<Adresse> adresses= dao.findByVille(ville);
            if (adresses.Count > 0)
            {
                return adresses;
            }
            else
            {
                throw new ListEmptyException("Aucune adresse ne correspond avec la ville " + ville);
            }
        }

        public Adresse findOneByCoordinates(double axe_x, double axe_y)
        {
            Adresse adresse=dao.findOneByCoordinates(axe_x, axe_y);
            if(adresse== null)
            {
                throw new NotFoundException("Aucune adresse ne correpond avec les" +
                    " coordonnées ("+axe_x+", "+axe_y+")");
            }
            else
            {
                return adresse;
            }
        }
        
        public Adresse findOneById(int id)
        {
            Adresse adresse= dao.findOneById(id);
            if (adresse != null)
            {
                return adresse;
            }
            else
            {
                throw new NotFoundException("Aucune adresse ne correpond avec l'id " + id);
            }
        }

        public List<Adresse> getAllAdresses()
        {
            List<Adresse> adresses= dao.getAllAdresses();
            if (adresses.Count > 0)
            {
                return adresses;
            }
            else
            {
                throw new ListEmptyException("Aucune adresse n'est enregistré");
            }
        }
    }
}
