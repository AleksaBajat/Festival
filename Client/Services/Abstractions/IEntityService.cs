using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Abstractions
{
    public interface IEntityService<T>
    {
        Task Add(T entity);

        Task Delete(T entity);

        Task Update(T entity);
    }
}
