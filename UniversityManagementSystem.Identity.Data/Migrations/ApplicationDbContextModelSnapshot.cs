﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversityManagementSystem.Identity.Data.Contexts;

namespace UniversityManagementSystem.Identity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    internal class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResource", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Created");

                b.Property<string>("Description")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasMaxLength(200);

                b.Property<bool>("Enabled");

                b.Property<DateTime?>("LastAccessed");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<bool>("NonEditable");

                b.Property<DateTime?>("Updated");

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("IdentityServerApiResources");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApiResourceId");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("IdentityServerApiClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApiResourceId");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("IdentityServerApiResourceProperties");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApiResourceId");

                b.Property<string>("Description")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasMaxLength(200);

                b.Property<bool>("Emphasize");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<bool>("Required");

                b.Property<bool>("ShowInDiscoveryDocument");

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("IdentityServerApiScopes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApiScopeId");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ApiScopeId");

                b.ToTable("IdentityServerApiScopeClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecret", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApiResourceId");

                b.Property<DateTime>("Created");

                b.Property<string>("Description")
                    .HasMaxLength(1000);

                b.Property<DateTime?>("Expiration");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(4000);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("IdentityServerApiSecrets");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.Client", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("AbsoluteRefreshTokenLifetime");

                b.Property<int>("AccessTokenLifetime");

                b.Property<int>("AccessTokenType");

                b.Property<bool>("AllowAccessTokensViaBrowser");

                b.Property<bool>("AllowOfflineAccess");

                b.Property<bool>("AllowPlainTextPkce");

                b.Property<bool>("AllowRememberConsent");

                b.Property<bool>("AlwaysIncludeUserClaimsInIdToken");

                b.Property<bool>("AlwaysSendClientClaims");

                b.Property<int>("AuthorizationCodeLifetime");

                b.Property<bool>("BackChannelLogoutSessionRequired");

                b.Property<string>("BackChannelLogoutUri")
                    .HasMaxLength(2000);

                b.Property<string>("ClientClaimsPrefix")
                    .HasMaxLength(200);

                b.Property<string>("ClientId")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<string>("ClientName")
                    .HasMaxLength(200);

                b.Property<string>("ClientUri")
                    .HasMaxLength(2000);

                b.Property<int?>("ConsentLifetime");

                b.Property<DateTime>("Created");

                b.Property<string>("Description")
                    .HasMaxLength(1000);

                b.Property<int>("DeviceCodeLifetime");

                b.Property<bool>("EnableLocalLogin");

                b.Property<bool>("Enabled");

                b.Property<bool>("FrontChannelLogoutSessionRequired");

                b.Property<string>("FrontChannelLogoutUri")
                    .HasMaxLength(2000);

                b.Property<int>("IdentityTokenLifetime");

                b.Property<bool>("IncludeJwtId");

                b.Property<DateTime?>("LastAccessed");

                b.Property<string>("LogoUri")
                    .HasMaxLength(2000);

                b.Property<bool>("NonEditable");

                b.Property<string>("PairWiseSubjectSalt")
                    .HasMaxLength(200);

                b.Property<string>("ProtocolType")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<int>("RefreshTokenExpiration");

                b.Property<int>("RefreshTokenUsage");

                b.Property<bool>("RequireClientSecret");

                b.Property<bool>("RequireConsent");

                b.Property<bool>("RequirePkce");

                b.Property<int>("SlidingRefreshTokenLifetime");

                b.Property<bool>("UpdateAccessTokenClaimsOnRefresh");

                b.Property<DateTime?>("Updated");

                b.Property<string>("UserCodeType")
                    .HasMaxLength(100);

                b.Property<int?>("UserSsoLifetime");

                b.HasKey("Id");

                b.HasIndex("ClientId")
                    .IsUnique();

                b.ToTable("IdentityServerClients");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("Origin")
                    .IsRequired()
                    .HasMaxLength(150);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientCorsOrigins");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("GrantType")
                    .IsRequired()
                    .HasMaxLength(250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientGrantTypes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("Provider")
                    .IsRequired()
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientIdPRestrictions");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("PostLogoutRedirectUri")
                    .IsRequired()
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientPostLogoutRedirectUris");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientProperties");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("RedirectUri")
                    .IsRequired()
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientRedirectUris");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<string>("Scope")
                    .IsRequired()
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientScopes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ClientId");

                b.Property<DateTime>("Created");

                b.Property<string>("Description")
                    .HasMaxLength(2000);

                b.Property<DateTime?>("Expiration");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(4000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("IdentityServerClientSecrets");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
            {
                b.Property<string>("UserCode")
                    .HasMaxLength(200);

                b.Property<string>("ClientId")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<DateTime>("CreationTime");

                b.Property<string>("Data")
                    .IsRequired()
                    .HasMaxLength(50000);

                b.Property<string>("DeviceCode")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<DateTime?>("Expiration")
                    .IsRequired();

                b.Property<string>("SubjectId")
                    .HasMaxLength(200);

                b.HasKey("UserCode");

                b.HasIndex("DeviceCode")
                    .IsUnique();

                b.ToTable("IdentityServerDeviceFlowCodes");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("IdentityResourceId");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("IdentityResourceId");

                b.ToTable("IdentityServerIdentityClaims");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResource", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Created");

                b.Property<string>("Description")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasMaxLength(200);

                b.Property<bool>("Emphasize");

                b.Property<bool>("Enabled");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<bool>("NonEditable");

                b.Property<bool>("Required");

                b.Property<bool>("ShowInDiscoveryDocument");

                b.Property<DateTime?>("Updated");

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("IdentityServerIdentityResources");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("IdentityResourceId");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("IdentityResourceId");

                b.ToTable("IdentityServerIdentityResourceProperties");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
            {
                b.Property<string>("Key")
                    .HasMaxLength(200);

                b.Property<string>("ClientId")
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property<DateTime>("CreationTime");

                b.Property<string>("Data")
                    .IsRequired()
                    .HasMaxLength(50000);

                b.Property<DateTime?>("Expiration");

                b.Property<string>("SubjectId")
                    .HasMaxLength(200);

                b.Property<string>("Type")
                    .IsRequired()
                    .HasMaxLength(50);

                b.HasKey("Key");

                b.HasIndex("SubjectId", "ClientId", "Type");

                b.ToTable("IdentityServerPersistedGrants");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Name")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("RoleId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasMaxLength(128);

                b.Property<string>("ProviderKey")
                    .HasMaxLength(128);

                b.Property<string>("ProviderDisplayName");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("RoleId");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("LoginProvider")
                    .HasMaxLength(128);

                b.Property<string>("Name")
                    .HasMaxLength(128);

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("UniversityManagementSystem.Identity.Data.Entities.ApplicationUser", b =>
            {
                b.Property<string>("Id");

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Email")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash");

                b.Property<string>("PhoneNumber");

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<string>("SecurityStamp");

                b.Property<bool>("TwoFactorEnabled");

                b.Property<string>("UserName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("UserClaims")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("Properties")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("Scopes")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "ApiScope")
                    .WithMany("UserClaims")
                    .HasForeignKey("ApiScopeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiSecret", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                    .WithMany("Secrets")
                    .HasForeignKey("ApiResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("Claims")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedCorsOrigins")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedGrantTypes")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("IdentityProviderRestrictions")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("PostLogoutRedirectUris")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("Properties")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("RedirectUris")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("AllowedScopes")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                    .WithMany("ClientSecrets")
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityClaim", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                    .WithMany("UserClaims")
                    .HasForeignKey("IdentityResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
            {
                b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                    .WithMany("Properties")
                    .HasForeignKey("IdentityResourceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.HasOne("UniversityManagementSystem.Identity.Data.Entities.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("UniversityManagementSystem.Identity.Data.Entities.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("UniversityManagementSystem.Identity.Data.Entities.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("UniversityManagementSystem.Identity.Data.Entities.ApplicationUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}