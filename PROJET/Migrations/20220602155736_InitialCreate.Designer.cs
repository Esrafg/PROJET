// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJET.Models;

#nullable disable

namespace PROJET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220602155736_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PROJET.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieID"), 1L, 1);

                    b.Property<string>("CategorieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PROJET.Models.Fournisseur", b =>
                {
                    b.Property<int>("FournisseurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FournisseurID"), 1L, 1);

                    b.Property<string>("FournisseurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FournisseurID");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("PROJET.Models.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduitID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("FournisseurID")
                        .HasColumnType("int");

                    b.Property<string>("ProduitCouleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProduitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProduitPrix")
                        .HasColumnType("float");

                    b.Property<string>("ProduitQteStock")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SousCategorieID")
                        .HasColumnType("int");

                    b.HasKey("ProduitID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("FournisseurID");

                    b.HasIndex("SousCategorieID");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("PROJET.Models.SousCategorie", b =>
                {
                    b.Property<int>("SousCategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SousCategorieID"), 1L, 1);

                    b.Property<int?>("CategorieID")
                        .HasColumnType("int");

                    b.Property<string>("SousCategorieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SousCategorieID");

                    b.HasIndex("CategorieID");

                    b.ToTable("SousCategories");
                });

            modelBuilder.Entity("PROJET.Models.Produit", b =>
                {
                    b.HasOne("PROJET.Models.Categorie", "CategorieP")
                        .WithMany()
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJET.Models.Fournisseur", "FournisseurP")
                        .WithMany("ListProduits")
                        .HasForeignKey("FournisseurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJET.Models.SousCategorie", "SousCategorieP")
                        .WithMany("ListProduits")
                        .HasForeignKey("SousCategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorieP");

                    b.Navigation("FournisseurP");

                    b.Navigation("SousCategorieP");
                });

            modelBuilder.Entity("PROJET.Models.SousCategorie", b =>
                {
                    b.HasOne("PROJET.Models.Categorie", null)
                        .WithMany("ListSousCategories")
                        .HasForeignKey("CategorieID");
                });

            modelBuilder.Entity("PROJET.Models.Categorie", b =>
                {
                    b.Navigation("ListSousCategories");
                });

            modelBuilder.Entity("PROJET.Models.Fournisseur", b =>
                {
                    b.Navigation("ListProduits");
                });

            modelBuilder.Entity("PROJET.Models.SousCategorie", b =>
                {
                    b.Navigation("ListProduits");
                });
#pragma warning restore 612, 618
        }
    }
}
