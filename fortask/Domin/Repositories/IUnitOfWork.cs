using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fortask.Domin.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
