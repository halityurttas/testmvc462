using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Managements
{
    public class TodoManager
    {
        Repositories.ITodoRepository todoRepository;

        public TodoManager()
            :this(RepositorFactory.Create<Repositories.ITodoRepository>())
        {
        }

        public TodoManager(Repositories.ITodoRepository todoRepositoryInstance)
        {
            this.todoRepository = todoRepositoryInstance;
        }

        public ICollection<Core.Models.TblTodo> GetTodos()
        {
            return AutoMapper.Mapper.Map<ICollection<Data.TblTodo>, ICollection<Core.Models.TblTodo>>(todoRepository.GetAll());
        }

        public Core.Models.TblTodo GetTodo(int key)
        {
            var data = todoRepository.Get(key);
            if (data == null)
            {
                return null;
            }
            else
            {
                return AutoMapper.Mapper.Map<Core.Models.TblTodo>(data);
            }
        }

        public int InsertTodo(Core.Models.TblTodo model)
        {
            var data = AutoMapper.Mapper.Map<Data.TblTodo>(model);
            return todoRepository.Insert(data);
        }

        public bool UpdateTodo(Core.Models.TblTodo model)
        {
            var data = AutoMapper.Mapper.Map<Data.TblTodo>(model);
            return todoRepository.Update(data);
        }

        public bool DeleteTodo(Core.Models.TblTodo model)
        {
            return todoRepository.Delete(model.Id);
        }
    }
}
