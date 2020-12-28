using System.ComponentModel.DataAnnotations.Schema;

namespace MontrealDatingApp.Entities
{
    [Table("Images")]
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfileImage { get; set; }
        public string PublicId { get; set; }

        /*
         * Below is for the cascade effect. If a user is deleted, we will
         * delete all of the images related to the user. Check the migrations
         *      constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
         */
        public User User { get; set; }
        public int UserId { get; set; }
    }
}