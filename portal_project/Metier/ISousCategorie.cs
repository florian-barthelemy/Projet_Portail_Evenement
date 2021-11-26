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
        void createSousCategorie(SousCategorie categorie);
        void editSousCategorie(SousCategorie categorie);
        void deleteSousCategorie(int id_categorie);
        List<SousCategorie> getAllSousCategories();
        List<SousCategorie> getAllSousCategoriesbyCategorie(string titre);

        SousCategorie findOneById(int id);
    }
}
