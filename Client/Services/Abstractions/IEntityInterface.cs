using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Abstractions
{
    public interface IEntityInterface<T>
    {
        Task Add(T entity);

        Task Duplicate(int id);

        Task Delete(int id);

        Task Update(T entity);

        Task GetAll(ObservableCollection<T> collection);
    }
}
