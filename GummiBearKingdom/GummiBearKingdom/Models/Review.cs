using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBearKingdom.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public bool FitsCharacters()
        {
            if (this.Body.Length <= 255)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
