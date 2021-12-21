using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.ViewModels
{
    public class UserLogViewModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string FullName { get; set; }
    }
}
