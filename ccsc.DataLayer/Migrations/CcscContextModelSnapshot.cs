﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ccsc.DataLayer.Context;

namespace ccsc.DataLayer.Migrations
{
    [DbContext(typeof(CcscContext))]
    partial class CcscContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("ProductVideo", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("VideosVideoId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "VideosVideoId");

                    b.HasIndex("VideosVideoId");

                    b.ToTable("ProductVideo");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("SalutationId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PostId");

                    b.HasIndex("SalutationId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Post", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Salutation", b =>
                {
                    b.Property<int>("SalutationId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SalutationId");

                    b.HasIndex("GenderId");

                    b.ToTable("Salutations");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ContractStatusId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("UnLimited")
                        .HasColumnType("bit");

                    b.HasKey("ContractId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.ContractCours", b =>
                {
                    b.Property<int>("ContractCoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("ContractCoursId");

                    b.HasIndex("ContractId");

                    b.HasIndex("CourseId");

                    b.ToTable("ContractCourses");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.ContractProduct", b =>
                {
                    b.Property<int>("ContractProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ContractProductId");

                    b.HasIndex("ContractId");

                    b.HasIndex("ProductId");

                    b.ToTable("ContractProducts");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.ContractType", b =>
                {
                    b.Property<int>("ContractTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ContractTypeId");

                    b.ToTable("ContractTypes");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Courses.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseLevelId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Courses.CourseLevel", b =>
                {
                    b.Property<int>("CourseLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseLevelId");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AfterXDay")
                        .HasColumnType("int");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActiveSms")
                        .HasColumnType("bit");

                    b.Property<decimal>("MinSMSCredit")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("SMSCredit")
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime?>("SMSCreditCheckDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SMSPass")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SMSUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("SendSmsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Version")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("VersionCheckDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.CustomerType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TypeId");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Os", b =>
                {
                    b.Property<int>("OsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OsId");

                    b.ToTable("Oses");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Hard")
                        .HasColumnType("int");

                    b.Property<int>("OsId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<int>("ServerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Vpn")
                        .HasColumnType("bit");

                    b.HasKey("ServerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OsId");

                    b.HasIndex("ServerTypeId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.ServerType", b =>
                {
                    b.Property<int>("ServerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ServerTypeId");

                    b.ToTable("ServerTypes");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Products.ChangeSet", b =>
                {
                    b.Property<int>("ChangeSetId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ChangeSetId");

                    b.HasIndex("UserId");

                    b.ToTable("ChangeSets");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Products.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Requests.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RequestChanelId")
                        .HasColumnType("int");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("ContactId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestChanelId");

                    b.HasIndex("RequestStatusId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Requests.RequestChanel", b =>
                {
                    b.Property<int>("RequestChanelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RequestChanelId");

                    b.ToTable("RequestChanels");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Requests.RequestStatus", b =>
                {
                    b.Property<int>("RequestStatusId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RequestStatusId");

                    b.ToTable("RequestStatuses");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Requests.RequestType", b =>
                {
                    b.Property<int>("RequestTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RequestTypeId");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Tutorials.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("VideoId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.UserRole", b =>
                {
                    b.Property<int>("UR_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ProductVideo", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Tutorials.Video", null)
                        .WithMany()
                        .HasForeignKey("VideosVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Contact", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Contacts.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Contacts.Salutation", "Salutation")
                        .WithMany()
                        .HasForeignKey("SalutationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Post");

                    b.Navigation("Salutation");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contacts.Salutation", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Contacts.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.Contract", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.ContractCours", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Contracts.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Courses.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Contracts.ContractProduct", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Contracts.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Courses.Course", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Courses.CourseLevel", "CourseLevel")
                        .WithMany()
                        .HasForeignKey("CourseLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Customer", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Customers.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Server", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Customers.Customer", "Customer")
                        .WithMany("Servers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Customers.Os", "Os")
                        .WithMany()
                        .HasForeignKey("OsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Customers.ServerType", "ServerType")
                        .WithMany()
                        .HasForeignKey("ServerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Os");

                    b.Navigation("ServerType");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Products.ChangeSet", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Requests.Request", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Contacts.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("ccsc.DataLayer.Entities.Requests.RequestChanel", "RequestChanel")
                        .WithMany()
                        .HasForeignKey("RequestChanelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Requests.RequestStatus", "RequestStatus")
                        .WithMany()
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Requests.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Product");

                    b.Navigation("RequestChanel");

                    b.Navigation("RequestStatus");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.UserRole", b =>
                {
                    b.HasOne("ccsc.DataLayer.Entities.Users.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ccsc.DataLayer.Entities.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Servers");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ccsc.DataLayer.Entities.Users.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
