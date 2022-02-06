using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecor.Business.Interfaces
{
    public interface IBaseBusiness<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Update(T entity);
        T Add(T entity);
        void Delete(int id);
    }
}
