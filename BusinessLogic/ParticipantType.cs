using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class ParticipantType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        [Display(Name = "Discription")]
        public string Descryption { get; set; }
        //[Required]
        //public int ParticipantTypeId { get; set; }

        //public List<Participants> participantList { get; set; }


    }
}
