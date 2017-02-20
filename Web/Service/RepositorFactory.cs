using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RepositorFactory
    {
        private static Dictionary<Type, Type> m_TypeBag = new Dictionary<Type, Type>()
        {
            {typeof(Repositories.ITodoRepository), typeof(Repositories.TodoRepository) }
        };

        public static TDomain Create<TDomain>()
        {
            return (TDomain)Activator.CreateInstance(m_TypeBag[typeof(TDomain)]);
        }
    }
}
