// <auto-generated />
using System;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    [Migration("20220302212317_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CounselorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CounselorId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("ContactId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("ContactTypeId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Domain.ContactType", b =>
                {
                    b.Property<int>("ContactTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.HasKey("ContactTypeId");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("Domain.Referred", b =>
                {
                    b.Property<int>("ReferredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("NutritionistId")
                        .HasColumnType("int");

                    b.HasKey("ReferredId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("NutritionistId");

                    b.ToTable("Referreds");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FirstLastName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SecondName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Domain.Nutritionist", b =>
                {
                    b.HasBaseType("Domain.User");

                    b.HasDiscriminator().HasValue("Nutritionist");
                });

            modelBuilder.Entity("Domain.Participant", b =>
                {
                    b.HasBaseType("Domain.User");

                    b.Property<string>("WicId")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Participant");
                });

            modelBuilder.Entity("Domain.Counselor", b =>
                {
                    b.HasBaseType("Domain.Participant");

                    b.HasDiscriminator().HasValue("Counselor");
                });

            modelBuilder.Entity("Domain.Assignment", b =>
                {
                    b.HasOne("Domain.Counselor", "Counselor")
                        .WithMany()
                        .HasForeignKey("CounselorId");

                    b.HasOne("Domain.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.HasOne("Domain.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Referred", b =>
                {
                    b.HasOne("Domain.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Nutritionist", "Nutritionist")
                        .WithMany()
                        .HasForeignKey("NutritionistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
