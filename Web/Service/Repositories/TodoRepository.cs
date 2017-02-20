using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class TodoRepository: EFRepositoryBase<TestContext, TblTodo, int>, ITodoRepository
    {
    }

    public interface ITodoRepository: IRepository<TblTodo, int>
    {

    }
}
