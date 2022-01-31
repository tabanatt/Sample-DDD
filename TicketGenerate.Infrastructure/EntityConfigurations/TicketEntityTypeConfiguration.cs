using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Infrastructure.EntityConfigurations
{
    public class TicketEntityTypeConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.ToTable("tickets", TicketContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .UseHiLo("ticketeq", TicketContext.DEFAULT_SCHEMA);

           // builder.OwnsOne(o => o.User);


             builder
             .OwnsOne(o => o.User, a =>
             {
                  a.Property<int>("TicketId")
                 .UseHiLo("ticketeq", TicketContext.DEFAULT_SCHEMA);
                 a.WithOwner();
             });

            builder
            .Property<string>("_title")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Title")
            .IsRequired(false);

            builder
            .Property<string>("_description")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Description")
            .IsRequired(false);

            builder
                .Property<DateTime>("_creationDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnType("date")
                .HasColumnName("CreationDate")
                .IsRequired();

        }
    }
}
