using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystem.Identity.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>(),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(),
                    TwoFactorEnabled = table.Column<bool>(),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(),
                    AccessFailedCount = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerApiResources",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerApiResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerClients",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(),
                    ClientId = table.Column<string>(maxLength: 200),
                    ProtocolType = table.Column<string>(maxLength: 200),
                    RequireClientSecret = table.Column<bool>(),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(),
                    AllowRememberConsent = table.Column<bool>(),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(),
                    RequirePkce = table.Column<bool>(),
                    AllowPlainTextPkce = table.Column<bool>(),
                    AllowAccessTokensViaBrowser = table.Column<bool>(),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(),
                    AllowOfflineAccess = table.Column<bool>(),
                    IdentityTokenLifetime = table.Column<int>(),
                    AccessTokenLifetime = table.Column<int>(),
                    AuthorizationCodeLifetime = table.Column<int>(),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(),
                    SlidingRefreshTokenLifetime = table.Column<int>(),
                    RefreshTokenUsage = table.Column<int>(),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(),
                    RefreshTokenExpiration = table.Column<int>(),
                    AccessTokenType = table.Column<int>(),
                    EnableLocalLogin = table.Column<bool>(),
                    IncludeJwtId = table.Column<bool>(),
                    AlwaysSendClientClaims = table.Column<bool>(),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(),
                    NonEditable = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerClients", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerDeviceFlowCodes",
                table => new
                {
                    UserCode = table.Column<string>(maxLength: 200),
                    DeviceCode = table.Column<string>(maxLength: 200),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(),
                    Data = table.Column<string>(maxLength: 50000)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerDeviceFlowCodes", x => x.UserCode); });

            migrationBuilder.CreateTable(
                "IdentityServerIdentityResources",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>(),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerIdentityResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerPersistedGrants",
                table => new
                {
                    Key = table.Column<string>(maxLength: 200),
                    Type = table.Column<string>(maxLength: 50),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerPersistedGrants", x => x.Key); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128),
                    ProviderKey = table.Column<string>(maxLength: 128),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(),
                    RoleId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(),
                    LoginProvider = table.Column<string>(maxLength: 128),
                    Name = table.Column<string>(maxLength: 128),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerApiClaims_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiResourceProperties",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiResourceProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerApiResourceProperties_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiScopes",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>(),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerApiScopes_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiSecrets",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250),
                    Created = table.Column<DateTime>(),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerApiSecrets_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 250),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientClaims_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientCorsOrigins",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(maxLength: 150),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientCorsOrigins_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientGrantTypes",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    GrantType = table.Column<string>(maxLength: 250),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientGrantTypes_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientIdPRestrictions",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Provider = table.Column<string>(maxLength: 200),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientIdPRestrictions_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientPostLogoutRedirectUris",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientProperties",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientProperties_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientRedirectUris",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    RedirectUri = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientRedirectUris_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientScopes",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Scope = table.Column<string>(maxLength: 200),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientScopes_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientSecrets",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250),
                    Created = table.Column<DateTime>(),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerClientSecrets_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerIdentityClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200),
                    IdentityResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerIdentityClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerIdentityClaims_IdentityServerIdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        "IdentityServerIdentityResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerIdentityResourceProperties",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    IdentityResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerIdentityResourceProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerIdentityResourceProperties_IdentityServerIdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        "IdentityServerIdentityResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiScopeClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 200),
                    ApiScopeId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiScopeId",
                        x => x.ApiScopeId,
                        "IdentityServerApiScopes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiClaims_ApiResourceId",
                "IdentityServerApiClaims",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiResourceProperties_ApiResourceId",
                "IdentityServerApiResourceProperties",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiResources_Name",
                "IdentityServerApiResources",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiScopeClaims_ApiScopeId",
                "IdentityServerApiScopeClaims",
                "ApiScopeId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiScopes_ApiResourceId",
                "IdentityServerApiScopes",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiScopes_Name",
                "IdentityServerApiScopes",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerApiSecrets_ApiResourceId",
                "IdentityServerApiSecrets",
                "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientClaims_ClientId",
                "IdentityServerClientClaims",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientCorsOrigins_ClientId",
                "IdentityServerClientCorsOrigins",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientGrantTypes_ClientId",
                "IdentityServerClientGrantTypes",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientIdPRestrictions_ClientId",
                "IdentityServerClientIdPRestrictions",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientPostLogoutRedirectUris_ClientId",
                "IdentityServerClientPostLogoutRedirectUris",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientProperties_ClientId",
                "IdentityServerClientProperties",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientRedirectUris_ClientId",
                "IdentityServerClientRedirectUris",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClients_ClientId",
                "IdentityServerClients",
                "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientScopes_ClientId",
                "IdentityServerClientScopes",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClientSecrets_ClientId",
                "IdentityServerClientSecrets",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerDeviceFlowCodes_DeviceCode",
                "IdentityServerDeviceFlowCodes",
                "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerIdentityClaims_IdentityResourceId",
                "IdentityServerIdentityClaims",
                "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerIdentityResourceProperties_IdentityResourceId",
                "IdentityServerIdentityResourceProperties",
                "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerIdentityResources_Name",
                "IdentityServerIdentityResources",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type",
                "IdentityServerPersistedGrants",
                new[] {"SubjectId", "ClientId", "Type"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "IdentityServerApiClaims");

            migrationBuilder.DropTable(
                "IdentityServerApiResourceProperties");

            migrationBuilder.DropTable(
                "IdentityServerApiScopeClaims");

            migrationBuilder.DropTable(
                "IdentityServerApiSecrets");

            migrationBuilder.DropTable(
                "IdentityServerClientClaims");

            migrationBuilder.DropTable(
                "IdentityServerClientCorsOrigins");

            migrationBuilder.DropTable(
                "IdentityServerClientGrantTypes");

            migrationBuilder.DropTable(
                "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropTable(
                "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                "IdentityServerClientProperties");

            migrationBuilder.DropTable(
                "IdentityServerClientRedirectUris");

            migrationBuilder.DropTable(
                "IdentityServerClientScopes");

            migrationBuilder.DropTable(
                "IdentityServerClientSecrets");

            migrationBuilder.DropTable(
                "IdentityServerDeviceFlowCodes");

            migrationBuilder.DropTable(
                "IdentityServerIdentityClaims");

            migrationBuilder.DropTable(
                "IdentityServerIdentityResourceProperties");

            migrationBuilder.DropTable(
                "IdentityServerPersistedGrants");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "IdentityServerApiScopes");

            migrationBuilder.DropTable(
                "IdentityServerClients");

            migrationBuilder.DropTable(
                "IdentityServerIdentityResources");

            migrationBuilder.DropTable(
                "IdentityServerApiResources");
        }
    }
}