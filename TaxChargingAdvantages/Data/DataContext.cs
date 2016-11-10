using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace TaxChargingAdvantages.Data
{
    class DataContext : DbContext
    {
        public DataContext() 
			: base("TaxConnectionString")
        {

        }
    }
}
