using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Modules.Customer.Infrastructure.EntityConfigurations
{
    public class NoteEntityConfiguration : IEntityTypeConfiguration<NoteDomain>
    {
        public void Configure(EntityTypeBuilder<NoteDomain> builder)
        {
            throw new NotImplementedException();
        }
    }
}
