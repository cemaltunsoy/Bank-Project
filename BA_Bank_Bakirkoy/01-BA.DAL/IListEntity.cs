using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_BA.DAL
{
    interface IListEntity<T> where T : class
    {
        List<T> GetAll();
        T GetById(int Id);
        List<T> GetByAll(Expression<Func<T, bool>> exprs);
    }
}
