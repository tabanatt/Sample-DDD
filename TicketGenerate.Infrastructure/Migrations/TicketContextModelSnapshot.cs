// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketGenerate.Infrastructure;

namespace TicketGenerate.Infrastructure.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.HasSequence("ticketeq", "ticket")
                .IncrementsBy(10);

            modelBuilder.Entity("TicketGenerate.Domain.AggregatesModel.TicketAggregate.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseHiLo("ticketeq", "ticket");

                    b.Property<DateTime>("_creationDate")
                        .HasColumnType("date")
                        .HasColumnName("CreationDate");

                    b.Property<string>("_description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("_title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("tickets", "ticket");
                });

            modelBuilder.Entity("TicketGenerate.Domain.AggregatesModel.TicketAggregate.Ticket", b =>
                {
                    b.OwnsOne("TicketGenerate.Domain.AggregatesModel.TicketAggregate.User", "User", b1 =>
                        {
                            b1.Property<int>("TicketId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseHiLo("ticketeq", "ticket");

                            b1.Property<string>("Fname")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Lname")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("MembershipDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Password")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Role")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Username")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TicketId");

                            b1.ToTable("tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
