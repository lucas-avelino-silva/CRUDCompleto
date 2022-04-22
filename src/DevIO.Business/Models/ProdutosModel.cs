using System.ComponentModel.DataAnnotations;

namespace AppMvcBasica.Models
{
    public class ProdutosModel: Entity
    {
        /*CHAVE ESTRANGEIRA*/
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        /*EF RELACAO -  VAI TER APENAS 1 FORNECEDOR E O FORNECEDOR VAI TER VARIOS PRODUTOS*/
        public FornecedorModel Fornecedor { get; set; }
    }
}
