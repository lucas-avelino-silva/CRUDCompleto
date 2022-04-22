using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMvcBasica.Models
{
    public class FornecedorModel: Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public EnumTipoFornecedor TipoFornecedor { get; set; }
        public EnderecosModel Endereco {get; set;}
        public bool Ativo { get; set; }

        /* EF RELACOES - FORNECEDOR VAI TER VARIOS PRODUTOS*/
        public IEnumerable<ProdutosModel> Produtos { get; set; }

    }
}
