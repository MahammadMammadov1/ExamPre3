using ExamPre3.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Core.Models
{
    public class Services : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string FaceUrl { get; set; }
        public string InstaUrl { get; set; }
        public string TwutUrl { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }

    }
}
