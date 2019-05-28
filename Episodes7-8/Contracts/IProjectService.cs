using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Contracts
{
    public interface IProjectService : IService
    {
        Task<string> GetProductName();

        Task<string> GetProductNameById(int id);

        Task AddProduct(int id, string name);
    }
}
