using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informer.Repository.Contract
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
