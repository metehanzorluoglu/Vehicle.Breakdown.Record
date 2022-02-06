using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleBreakdownRecord.DAL.Interfaces
{
    public interface IBaseInterface<T> where T : class
    {
        List<T> GetAll();
        T GetByID(int id);
        T Update(T entity);
        T Add(T entity);
        void Delete(int id);
    }
}
