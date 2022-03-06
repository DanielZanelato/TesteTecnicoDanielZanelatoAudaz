using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoDanielZanelato.Models
{
    public class Operator : IModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Fare Fare { get; set; }

        public Operator(Guid id, string code)
        {
            Code = code;
            Id = id;
        }
    }
}
