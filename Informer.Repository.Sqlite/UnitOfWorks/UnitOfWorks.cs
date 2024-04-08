using Informer.Repository.Contract;
using Informer.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informer.Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly InformerDbContext _eFDbContext;

    public UnitOfWork(InformerDbContext eFDbContext)
    {
        _eFDbContext = eFDbContext;
    }

    public async Task Commit()
    {
        await _eFDbContext.SaveChangesAsync();
    }
}
