﻿// <auto-generated />
using System;
using Api.Issuing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Issuing.Migrations
{
    [DbContext(typeof(IssuingDbContext))]
    [Migration("20220607153753_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("IssuingOrg2")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Issuing.Model.ConnectionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortalUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ReceivedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("StaffMemberId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.HasIndex("Status");

                    b.ToTable("ConnectionRequests", "IssuingOrg2");
                });

            modelBuilder.Entity("Api.Issuing.Model.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("IssuedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SourceOrganisation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.HasIndex("Status");

                    b.ToTable("Credentials", "IssuingOrg2");
                });

            modelBuilder.Entity("Api.Issuing.Model.Presentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("StaffMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("Presentations", "IssuingOrg2");
                });

            modelBuilder.Entity("Api.Issuing.Model.StaffMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StaffMembers", "IssuingOrg2");
                });

            modelBuilder.Entity("CredentialPresentation", b =>
                {
                    b.Property<int>("CredentialsId")
                        .HasColumnType("int");

                    b.Property<int>("PresentationsId")
                        .HasColumnType("int");

                    b.HasKey("CredentialsId", "PresentationsId");

                    b.HasIndex("PresentationsId");

                    b.ToTable("CredentialPresentation", "IssuingOrg2");
                });

            modelBuilder.Entity("Api.Issuing.Model.ConnectionRequest", b =>
                {
                    b.HasOne("Api.Issuing.Model.StaffMember", "StaffMember")
                        .WithMany("ConnectionRequests")
                        .HasForeignKey("StaffMemberId");

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("Api.Issuing.Model.Credential", b =>
                {
                    b.HasOne("Api.Issuing.Model.StaffMember", "StaffMember")
                        .WithMany("Credentials")
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("Api.Issuing.Model.Presentation", b =>
                {
                    b.HasOne("Api.Issuing.Model.StaffMember", "StaffMember")
                        .WithMany("Presentations")
                        .HasForeignKey("StaffMemberId");

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("CredentialPresentation", b =>
                {
                    b.HasOne("Api.Issuing.Model.Credential", null)
                        .WithMany()
                        .HasForeignKey("CredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Issuing.Model.Presentation", null)
                        .WithMany()
                        .HasForeignKey("PresentationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Issuing.Model.StaffMember", b =>
                {
                    b.Navigation("ConnectionRequests");

                    b.Navigation("Credentials");

                    b.Navigation("Presentations");
                });
#pragma warning restore 612, 618
        }
    }
}
