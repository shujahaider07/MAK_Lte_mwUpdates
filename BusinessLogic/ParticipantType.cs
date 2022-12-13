using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class ParticipantType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Discription is required")]
        [Display(Name = "Discription")]
        public string Descryption { get; set; }
        //[Required]
        //public int ParticipantTypeId { get; set; }

        //public List<Participants> participantList { get; set; }


    }
}
