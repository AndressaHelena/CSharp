using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace AjusteSalarial
{
    public class ColaboradoresAntigos : Colaborador
    {
        public double ajuste { get; set; }

        public ColaboradoresAntigos(string nome, string cargo, double salarioAtual, double ajuste): base(nome, cargo, salarioAtual)
        {
      
            this.ajuste = ajuste;
        }

        public void getReajuste() {
            double calculo = base.salarioAtual * ajuste;
            double salarioNovo = base.salarioAtual + calculo;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(nome + ", seu novo salario é " + salarioNovo.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")) + " com reajuste de " + calculo.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine("--------------------------------------------------------");
        }
    }
}
