using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using am_pm_solutions.Entities;
using System.Data.Entity;

namespace am_pm_solutions.DAL
{
    public class AmPmContext : DbContext
    {
        public AmPmContext()
            : base("AmPmContext")
        { }

        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<BolsaTrabajo> BolsaTrabajo { get; set; }
    }
}
