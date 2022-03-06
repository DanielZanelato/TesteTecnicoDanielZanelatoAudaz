using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoDanielZanelato.Models;

namespace TesteTecnicoDanielZanelato.Services
{
    public class OperatorService
    {
        public Repository _repository = new Repository();

        public Operator GetOperatorByCode(string code)
        {
            var operators = _repository.GetAll<Operator>();
            return operators.FirstOrDefault(o => o.Code == code);
        }
        public Operator GetOperatorById(Guid id)
        {
            return _repository.GetById<Operator>(id);
        }
        public List<Operator> GetOperators()
        {
            return _repository.GetAll<Operator>();
        }
        public void Create(Operator insertingOperator)
        {
            _repository.Insert(insertingOperator);
        }
        public void Update(Operator updatingOperator)
        {
            _repository.Update(updatingOperator);
        }
        public void StartData()
        {
            var operatorOP01 = new Operator(Guid.NewGuid(), "OP01");
            var operatorOP02 = new Operator(Guid.NewGuid(), "OP02");
            var operatorOP03 = new Operator(Guid.NewGuid(), "OP03");
            var operatorOP04 = new Operator(Guid.NewGuid(), "OP04");
            Create(operatorOP01);
            Create(operatorOP02);
            Create(operatorOP03);
            Create(operatorOP04);
        }
    }
}
