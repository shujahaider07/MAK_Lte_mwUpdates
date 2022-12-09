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
        public int AssociationId { get; set; }
        public int PaticipantId { get; set; }
        public string FieldName { get; set; }
        public int InternalFieldId { get; set; }
        public int EncodingTypeId { get; set; }
        public string Alias { get; set; }
        public int PaticipantTypeId { get; set; }
        public string ParentTagId { get; set; }
        public char Identifier { get; set; }
        public char Mask { get; set; }
        public int Encrypt { get; set; }
        public int BitmappedId { get; set; }
        public int BitNumber { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public char Delimiter { get; set; }
        public string MetaLengthTypeId { get; set; }
        public string MetaLength { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }


    }
}
