using System;
using TesteTecnicoDanielZanelato.Models;
using TesteTecnicoDanielZanelato.Services;

namespace TesteTecnicoDanielZanelato.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();
        }
        public void CreateFare(Fare fare, string operatorCode)
        {

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorId = selectedOperator.Id;
            CreationFareElements(fare);
            if (selectedOperator.Fare == null) selectedOperator.Fare = fare;
            var selectedOperatorFare = selectedOperator.Fare;

            if (VerificationCreateFare(selectedOperatorFare))
            {
                fare.Status = 1;
                CreationFareWithElements(fare);
            }
            else ErrorToCreateFare(fare);
        }
        private void ErrorToCreateFare(Fare fare)
        {
            var today = DateTime.Now;
            var fareDay = fare.EndDate.Month - today.Month;
            Console.WriteLine("Erro ao criar tarifa :( O tempo para poder cadastrar nessa operadora é de: " + fareDay + " Meses");
        }
        public void CreationFareElements(Fare fare)
        {
            fare.CreationDate = DateTime.Now;
            fare.EndDate = fare.CreationDate.AddMonths(6);
        }
        private void CreationFareWithElements(Fare fare)
        {
            _fareService.Create(fare);
            Console.WriteLine("Tarifa cadastrada com sucesso!");
        }
        private bool VerificationCreateFare(Fare selectedOperatorFare)
        {
            var fares = _fareService.GetFares();
            foreach(var fare in fares)
            {
                if (fare.Value == selectedOperatorFare.Value) return false;
            }
            var today = DateTime.Now;
            return selectedOperatorFare.Status == 0 
                && selectedOperatorFare.EndDate >= today;
        }
        public void StartDataToOperatorFare()
        {
            var operatorOP01 = new Operator(Guid.NewGuid(), "OP01");
            var operatorOP02 = new Operator(Guid.NewGuid(), "OP02");
            var operatorOP03 = new Operator(Guid.NewGuid(), "OP03");
            var operatorOP04 = new Operator(Guid.NewGuid(), "OP04");
            _operatorService.Create(operatorOP01);
            _operatorService.Create(operatorOP02);
            _operatorService.Create(operatorOP03);
            _operatorService.Create(operatorOP04);
        }
        public void PrintDB()
        {
            var fares = _fareService.GetFares();
            foreach(var fare in fares)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Id da tarifa: "+fare.Id);
                Console.WriteLine("Id da operadora vinculada a tarifa: "+fare.OperatorId);
                Console.WriteLine("Valor da Tarifa: "+fare.Value.ToString("C"));
            }
        }
    }
}
