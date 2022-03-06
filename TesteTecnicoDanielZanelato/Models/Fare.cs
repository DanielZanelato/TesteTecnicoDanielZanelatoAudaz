using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoDanielZanelato.Models
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public int Status = 0;
        public float Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
