using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolmRakendust_Tiora
{
    public partial class loginpass
    {
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
