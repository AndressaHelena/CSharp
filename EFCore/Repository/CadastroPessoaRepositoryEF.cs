using EFCore.Models;
using EFCore.Repository.Context;


namespace EFCore.Repository
{
    public class CadastroPessoaRepositoryEF
    {
        // Propriedade que terá a instância do DataBaseContext

        private readonly DataBaseContext context;

        //constructor (função com mesmo nome da classe)
        public CadastroPessoaRepositoryEF()
        {
            // Criando um instância da classe de contexto do EntityFramework
            DataBaseContext context = new DataBaseContext();
        }


        public IList<CadastroPessoa> Listar()
        {
            return context.CadastroPessoa.ToList();
        }


        public IList<CadastroPessoa> ListarOrdenadoPorNome()

        {
            var lista =
             context.CadastroPessoa.OrderBy(t => t.NomePessoa).ToList<CadastroPessoa>();

            return lista;
        }

        public IList<CadastroPessoa> ListarOrdenadoPorNomeDescendente()
        {
            var lista =
                context.CadastroPessoa.OrderByDescending(t => t.NomePessoa).ToList<CadastroPessoa>();

            return lista;
        }
        /*
        public IList<CadastroPessoa> ListarEndereco()
        {
            var lista =
               context.CadastroPessoa.OrderByDescending(t => t.EnderecoPessoa).ToList<CadastroPessoa>();

            return lista;

        }
        public IList<CadastroPessoa> ListarEmail()
        {
            var lista =
               context.CadastroPessoa.OrderByDescending(t => t.EmailPessoa).ToList<CadastroPessoa>();

            return lista;

        }
        */

        public CadastroPessoa ConsultaPorNome(string nome)
        {
            // Retorno único
            CadastroPessoa pessoa =
                context.CadastroPessoa.Where(t => t.NomePessoa == nome)
                    .FirstOrDefault<CadastroPessoa>();

            return pessoa;
        }

        public IList<CadastroPessoa> ListarTiposParteNome(string parteNome)
        {
            // Filtro com Where e Contains
            var lista =
                context.CadastroPessoa.Where(t => t.NomePessoa.Contains(parteNome))
                        .ToList<CadastroPessoa>();

            return lista;
        }

        public CadastroPessoa Consultar(int id)
        {
            return context.CadastroPessoa.Find(id);
        }


        public void Inserir(CadastroPessoa cadrastroPessoa)
        {
            context.CadastroPessoa.Add(cadrastroPessoa);
            context.SaveChanges();
        }

        public void Alterar(CadastroPessoa cadrastroPessoa)
        {
           context.CadastroPessoa.Update(cadrastroPessoa);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um cadastro apenas com o Id
            var cadrastroPessoa = new CadastroPessoa()
            {
                Id = id
            };

            context.CadastroPessoa.Remove(cadrastroPessoa);
            context.SaveChanges();
        }
    }
}
