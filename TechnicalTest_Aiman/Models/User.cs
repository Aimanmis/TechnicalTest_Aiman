using System.ComponentModel.DataAnnotations;

namespace TechnicalTest_Aiman.Models
{
    public class tbl_user
    {
        [Key]
        public int UserId { get; set; }
        public string? NamaLengkap { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        [Display(Name = "Status")]
        [UIHint("StatusDropdown")]
        public char Status { get; set; }
    }
}
