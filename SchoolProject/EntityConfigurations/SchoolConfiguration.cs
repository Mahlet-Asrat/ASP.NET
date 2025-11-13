using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApi.SchoolProject.Models;

namespace SchoolApi.SchoolProject.EntityConfigurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<ISchool>
    {
        public void Configure(EntityTypeBuilder<ISchool> builder)
        {
            builder.ToTable("Schools");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name).HasMaxLength(200).IsRequired();
            builder.Property(v => v.Director).HasMaxLength(100);
            builder.Property(v => v.Teachers).HasMaxLength(100).IsUnicode(false);
            builder.Property(v => v.Students).HasMaxLength(100).IsUnicode(false);
            builder.OwnsMany(v => v.Teachers);
            builder.OwnsMany(v => v.Students);

        }
    }
}
