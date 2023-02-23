using HamburgerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerApp.DataAccess.EntityFramework.Mapping
{
    public class OrderMapping :BaseEntityTypeConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            base.Configure(builder);
        }
    }
}
