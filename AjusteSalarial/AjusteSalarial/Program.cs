using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AjusteSalarial;


namespace AjusteSalarial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Colaborador> colaboradores = new List<Colaborador> { };

            Console.Write("\n 1 - Cadastrar colaborador \n 2 - Finalizar \n Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
            
            
            while (opcao == 1)
            {
                Console.Write("\n 1 - Cadastrar colaborador antigo \n 2 - Cadastrar colaborador novo \n  Opção: ");
                int eAntigo = Convert.ToInt32(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
                
                Console.Write("\n Qual o nome do colaborador? ");
                string nome = Console.ReadLine();
                
                Console.Write(" Qual o cargo do colaborador? ");
                string cargo = Console.ReadLine();
                
                Console.Write(" Qual o salário? ");
                double salario = Convert.ToDouble(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));

                Colaborador colaborador = new Colaborador(nome, cargo, salario);

                if (eAntigo == 1)
                {
                    ColaboradoresAntigos colaboradoresAntigos = new ColaboradoresAntigos(nome, cargo, salario, 0.1);
                    if (salario <= 7000)
                    {
                        Console.WriteLine(" Digite o ajuste ");
                        colaboradoresAntigos.ajuste = (Convert.ToDouble(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR")));
                        
                    }
                    colaboradoresAntigos.getReajuste();
                }
            }
        }
    }
}