using forumapp.entity.db;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forumapp.repository.entityconfiguration
{
    public class CategoryConfiguration : EntityTypeConfiguration<dbCategory>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired();

            Property(c => c.Description)
                .HasColumnName("Description")
                .IsOptional();
        }
    }
}
