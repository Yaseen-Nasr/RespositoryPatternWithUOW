using RespositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.Core.Models;
using RespositoryPatternWithUOW.EF.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRespository<Author> Authors { get; private set; }
        public IBaseRespository<Book> Books { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRespository<Author>(_context);
            Books = new BaseRespository<Book>(_context);
        }

        public int Complete()
        {
            return _context.SaveChangesAsync().Result;
        }

        public void Dispose()
        {
          _context.Dispose();
        }
    }
}
