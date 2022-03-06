using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoDanielZanelato.Models;

namespace TesteTecnicoDanielZanelato.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }
        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }
        public Fare GetFareById(Guid fareId)
        {
            return _repository.GetById<Fare>(fareId);
        }
        public List<Fare> GetFares()
        {
            return _repository.GetAll<Fare>();
        }
    }
}
