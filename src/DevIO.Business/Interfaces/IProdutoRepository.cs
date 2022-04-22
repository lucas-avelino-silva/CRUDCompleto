using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository: IRepository<ProdutosModel>
    {
        Task<ProdutosModel> ObterProdutoFornecedor(Guid id);
        Task<IEnumerable<ProdutosModel>> ObterProdutosFornecedores();
        Task<IEnumerable<ProdutosModel>> ObterProdutoPorFornecedor(Guid fornecedorId);
    }
}
