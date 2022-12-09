﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Bins { get; set; }
        [Required]
        //[Display(Name= "IsEcho Enable ")]
        public char IsEchoEnable  { get; set; }
        [Required]
        public int MsgEchoTimer { get; set; }
        [Required]
        public char IsActive { get; set; }
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }

        //public List<Association> AssociationList { get; set; }

    }
}