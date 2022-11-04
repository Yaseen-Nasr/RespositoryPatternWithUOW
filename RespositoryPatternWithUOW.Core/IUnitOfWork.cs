using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRespository<Author> Authors { get; }
        IBaseRespository<Book> Books { get; }
        int Complete();

    }
}
