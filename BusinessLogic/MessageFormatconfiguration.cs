using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MessageFormatconfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public int PaticipantId { get; set; }
        [Required]
        public string FieldName { get; set; }
        [Required]
        public int InternalFieldId { get; set; }
        [Required]
        public int EncodingTypeId { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public int PaticipantTypeId { get; set; }
        [Required]
        public string ParentTagId { get; set; }
        [Required]
        public char Identifier { get; set; }
        [Required]
        public char Mask { get; set; }
        [Required]
        public int Encrypt { get; set; }
        [Required]
        public int BitmappedId { get; set; }
        [Required]
        public int BitNumber { get; set; }
        [Required]
        public int StartIndex { get; set; }
        [Required]
        public int EndIndex { get; set; }
        [Required]
        public char Delimiter { get; set; }
        [Required]
        public string MetaLengthTypeId { get; set; }
        [Required]
        public string MetaLength { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        


    }
}
