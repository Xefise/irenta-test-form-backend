﻿// <auto-generated />
using System;
using IrentaFormTestBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IrentaFormTestBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230409212230_filemodel")]
    partial class filemodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("IrentaFormTestBackend.Models.FileModel", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FileModels");
                });

            modelBuilder.Entity("IrentaFormTestBackend.Models.OwnershipBankDetails", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankBranchName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Bic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckingAccount")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("CorrespondentAccount")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<ulong>("OwnershipFormModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnershipFormModelId");

                    b.ToTable("OwnershipBankDetailsList");
                });

            modelBuilder.Entity("IrentaFormTestBackend.Models.OwnershipFormModel", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("Inn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NoAgreement")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("Ogrnip")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("ScanEgripId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ScanInnId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ScanLeaseAgreementId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ScanOgrnipId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScanEgripId");

                    b.HasIndex("ScanInnId");

                    b.HasIndex("ScanLeaseAgreementId");

                    b.HasIndex("ScanOgrnipId");

                    b.ToTable("OwnershipFormModels");
                });

            modelBuilder.Entity("IrentaFormTestBackend.Models.OwnershipBankDetails", b =>
                {
                    b.HasOne("IrentaFormTestBackend.Models.OwnershipFormModel", "OwnershipFormModel")
                        .WithMany("OwnershipBankDetailsList")
                        .HasForeignKey("OwnershipFormModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnershipFormModel");
                });

            modelBuilder.Entity("IrentaFormTestBackend.Models.OwnershipFormModel", b =>
                {
                    b.HasOne("IrentaFormTestBackend.Models.FileModel", "ScanEgrip")
                        .WithMany()
                        .HasForeignKey("ScanEgripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IrentaFormTestBackend.Models.FileModel", "ScanInn")
                        .WithMany()
                        .HasForeignKey("ScanInnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IrentaFormTestBackend.Models.FileModel", "ScanLeaseAgreement")
                        .WithMany()
                        .HasForeignKey("ScanLeaseAgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IrentaFormTestBackend.Models.FileModel", "ScanOgrnip")
                        .WithMany()
                        .HasForeignKey("ScanOgrnipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScanEgrip");

                    b.Navigation("ScanInn");

                    b.Navigation("ScanLeaseAgreement");

                    b.Navigation("ScanOgrnip");
                });

            modelBuilder.Entity("IrentaFormTestBackend.Models.OwnershipFormModel", b =>
                {
                    b.Navigation("OwnershipBankDetailsList");
                });
#pragma warning restore 612, 618
        }
    }
}
