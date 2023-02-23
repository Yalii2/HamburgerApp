using HamburgerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.DataAccess.EntityFramework.Mapping
{
    public class ProductMapping:BaseEntityTypeConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            base.Configure(builder);
        }
    }
}
