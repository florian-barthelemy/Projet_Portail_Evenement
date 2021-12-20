using portal_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.ViewModels
{
    public class EventSousCatViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<SousCategorie> SousCategories { get; set; }
    }
}
