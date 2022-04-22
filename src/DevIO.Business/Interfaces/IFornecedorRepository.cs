using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorRepository: IRepository<FornecedorModel>
    {
        Task<FornecedorModel> ObterFornecedorEndereco(Guid id);
        Task<FornecedorModel> ObterFornecedorProdutosEndereco(Guid id);
    }
}
