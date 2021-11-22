using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Metier
{
    public interface IAdresse
    {
        void createAdress(Adresse adresse);
        void editAdress(Adresse adresse);
        void deleteAdresse(int id_adresse);
        List<Adresse> getAllAdresses();
        Adresse findOneById(int id);
        Adresse findOneByCoordinates(int[] coordinates);
        List<Adresse> findByVille(string ville);
        List<Adresse> findByCodePostal(string code_postal);

    }
}
