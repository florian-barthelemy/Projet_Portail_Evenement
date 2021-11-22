using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Metier
{
    public interface ISousCategorie
    {
        void createSousCategorie(Categorie categorie);
        void editSousCategorie(Categorie categorie);
        void deleteSousCategorie(int id_categorie);
        List<Categorie> getAllCategories();
        Categorie findOneById(int id);
    }
}
