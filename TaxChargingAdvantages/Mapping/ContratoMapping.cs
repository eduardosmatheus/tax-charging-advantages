using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using Core;

namespace TaxChargingAdvantages.Mapping
{
    class ContratoMapping : EntityTypeConfiguration<ContratoDeTrabalho>
    {
        ContratoMapping()
        {
            ToTable("contrato");
        }
    }
}
