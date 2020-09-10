using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
