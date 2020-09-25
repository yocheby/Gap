using System;
using System.Collections.Generic;

namespace GAP.Business
{
    public interface IServiceCrud<T>
    {
        void Save(T message);

        List<T> GetList();

        T GetById(Guid id);

        void Delete(Guid id);
    }
}
