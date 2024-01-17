using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Business.CustomExceptions.ServiceExceptions
{
    public class TrainerNullException : Exception
    {
        public string Prop { get; set; }
        public TrainerNullException()
        {
        }

        public TrainerNullException(string ex, string? message) : base(message) 
        {
            Prop = ex;
        }
    }
}
