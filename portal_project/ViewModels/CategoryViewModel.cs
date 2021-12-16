using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.ViewModels
{
    public class CategoryViewModel
    {
        public Categorie Categorie { get; set; }
        public IEnumerable<SousCategorie> LstSousCategories { get; set; }

    }
}
