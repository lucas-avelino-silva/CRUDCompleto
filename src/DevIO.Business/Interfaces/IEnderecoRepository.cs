using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository: IRepository<EnderecosModel>
    {
        Task<EnderecosModel> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
