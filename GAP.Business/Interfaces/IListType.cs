namespace GAP.Business.Interfaces
{
    using System.Collections.Generic;

    public interface IListType<T>
    {
        List<T> GetList();
    }
}
