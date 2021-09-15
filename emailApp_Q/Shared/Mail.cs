using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emailApp_Q.Shared
{
    public class Mail
    {
        [Column("MailId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sender is a required field.")]
        [EmailAddress]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Reciver is a required field.")]
        [EmailAddress]
        public string Reciver { get; set; }


        [RegularExpression(@"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*$", ErrorMessage = "EmailAddresses are not valid")]
        public string CC { get; set; }

        [Required(ErrorMessage = "Subject is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Subject is 50 characters.")]
        public string Subject { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select importance")]
        [Required(ErrorMessage = "Importance is a required field.")]
        [ForeignKey(nameof(Importance))]
        public int ImportanceId { get; set; }
        public Importance Importance { get; set; }

        [Required(ErrorMessage = "Content is a required field.")]
        public string Content { get; set; }
    }
}
