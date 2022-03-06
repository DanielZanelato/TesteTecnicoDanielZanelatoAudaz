using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoDanielZanelato.Controllers;
using TesteTecnicoDanielZanelato.Models;
using TesteTecnicoDanielZanelato.Services;

namespace TesteTecnicoDanielZanelato
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var fareController = new FareController();
            fareController.StartDataToOperatorFare();

            Console.WriteLine("------- Ola! Seja Bem vindo! ----------");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("4 Operadores já foram adicionados automaticamente");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Você irá digitar o valor da tarifa e dps escolher" +
                "\n um desses operdores ja adicionados!");
            Console.WriteLine("As opções sao: 'OP01', 'OP02', 'OP03', 'OP04'");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Lembrando q voce nao poderá adicionar uma tarifa ao" +
                "\n um mesmo operador! îsso só poderá ser feito depois de 6 meses!");
            Console.WriteLine("------------------------------------------------------");

            string answer = "1";
            while (answer == "1")
            {
                var fare = new Fare();
                fare.Id = Guid.NewGuid();
                
                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = float.Parse(fareValueInput);

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("OP01, OP02, OP03 ou OP04");
                var operatorCodeInput = Console.ReadLine();

                fareController.CreateFare(fare, operatorCodeInput);

                Console.WriteLine("O que deseja fazer agora?");
                Console.WriteLine("Deseja cadastrar outra tarifa?");
                Console.WriteLine("1 - Sim, 2 - Sair, 3 - Mostrar tarifas");
                answer = Console.ReadLine();
                if(answer == "3")
                {
                    fareController.PrintDB();
                    answer = "1";
                }
            }
        }
    }
}
