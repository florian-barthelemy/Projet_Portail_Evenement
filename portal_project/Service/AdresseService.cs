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
            dao.createAdress(adresse);
        }

        public void deleteAdresse(int id_adresse)
        {
            dao.deleteAdresse(id_adresse);
        }

        public void editAdress(Adresse adresse)
        {
            dao.editAdress(adresse);
        }

        public List<Adresse> findByCodePostal(string code_postal)
        {
            return dao.findByCodePostal(code_postal);
        }

        public List<Adresse> findByVille(string ville)
        {
            return dao.findByVille(ville);
        }

        public Adresse findOneByCoordinates(double axe_x, double axe_y)
        {
            return dao.findOneByCoordinates(axe_x, axe_y);
        }
        
        public Adresse findOneById(int id)
        {
            return dao.findOneById(id);
        }

        public List<Adresse> getAllAdresses()
        {
            return dao.getAllAdresses();
        }
    }
}
