using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boolflix.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChild = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreVideoContent",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    VideoContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreVideoContent", x => new { x.GenresId, x.VideoContentsId });
                    table.ForeignKey(
                        name: "FK_GenreVideoContent_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreVideoContent_VideoContents_VideoContentsId",
                        column: x => x.VideoContentsId,
                        principalTable: "VideoContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileVideoContent",
                columns: table => new
                {
                    ProfilesId = table.Column<int>(type: "int", nullable: false),
                    VideoContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileVideoContent", x => new { x.ProfilesId, x.VideoContentsId });
                    table.ForeignKey(
                        name: "FK_ProfileVideoContent_Profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileVideoContent_VideoContents_VideoContentsId",
                        column: x => x.VideoContentsId,
                        principalTable: "VideoContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistVideoContent",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false),
                    VideoContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistVideoContent", x => new { x.PlaylistsId, x.VideoContentsId });
                    table.ForeignKey(
                        name: "FK_PlaylistVideoContent_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistVideoContent_VideoContents_VideoContentsId",
                        column: x => x.VideoContentsId,
                        principalTable: "VideoContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreVideoContent_VideoContentsId",
                table: "GenreVideoContent",
                column: "VideoContentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_ProfileId",
                table: "Playlists",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistVideoContent_VideoContentsId",
                table: "PlaylistVideoContent",
                column: "VideoContentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileVideoContent_VideoContentsId",
                table: "ProfileVideoContent",
                column: "VideoContentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreVideoContent");

            migrationBuilder.DropTable(
                name: "PlaylistVideoContent");

            migrationBuilder.DropTable(
                name: "ProfileVideoContent");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "VideoContents");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
