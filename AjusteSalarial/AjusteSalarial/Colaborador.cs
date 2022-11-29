using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjusteSalarial
{
    public class Colaborador : IColaborador
    {
        protected string nome{ get; set; }
        
        protected string cargo { get; set; }

        protected double salarioAtual { get; set; }

        public Colaborador(string nome, string cargo, double salarioAtual)
        {
            this.nome = nome;
            this.cargo = cargo;
            this.salarioAtual = salarioAtual;
        }

        void IColaborador.Colaborador()
        {
            throw new NotImplementedException();
        }
    }
}
