using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Concretes
{
    public class BreakdownListRepository : IBreakdownListRepository
    {
        public BreakdownList Add(BreakdownList entity)
        {
            using (var context = new VehicleDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var context = new VehicleDbContext())
            {
                context.BreakdownLists.Remove(GetByID(id));
                context.SaveChanges();
            }
        }

        public List<BreakdownList> GetAll()
        {
            using(var context= new VehicleDbContext())
            {
                return context.BreakdownLists.ToList();
            }
        }

        public BreakdownList GetByID(int id)
        {
            using (var context = new VehicleDbContext())
            {
                return context.BreakdownLists.Find(id);
            }
        }

        public BreakdownList Update(BreakdownList entity)
        {
            using (var context = new VehicleDbContext())
            {
                context.BreakdownLists.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
