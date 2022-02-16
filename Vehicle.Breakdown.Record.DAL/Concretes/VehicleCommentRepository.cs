using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL.Concretes
{
    public class VehicleCommentRepository : IVehicleCommentRepository
    {
        public VehicleComment Add(VehicleComment entity)
        {
            using (var context = new AppDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                context.VehicleComments.Remove(GetByID(id));
                context.SaveChanges();
            }
        }

        public List<VehicleComment> GetAll()
        {
            using (var context =new AppDbContext())
            {
                return context.VehicleComments.ToList();
            }
        }

        public VehicleComment GetByID(int id)
        {
            using (var context= new AppDbContext())
            {
                return context.VehicleComments.Find(id);
            }
        }

        public VehicleComment Update(VehicleComment entity)
        {
            using (var context = new AppDbContext())
            {
                context.VehicleComments.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }
    }
}
