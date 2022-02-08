using AutoMapper;
using System;
using System.Collections.Generic;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Concretes
{
    public class VehicleCommentBusiness : IVehicleCommentBusiness
    {
        private readonly IBaseInterface<VehicleComment> _comment;
        private IMapper _mapper;

        public VehicleCommentBusiness(IMapper mapper, IBaseInterface<VehicleComment> comment)
        {
            _mapper = mapper;
            _comment = comment;
        }

        public VehicleCommentDto Add(VehicleCommentDto entity)
        {
            entity.CreateDate = DateTime.Now;
            var breakDown = _mapper.Map<VehicleComment>(entity);
            _comment.Add(breakDown);
            return entity;
        }

        public void Delete(int id)
        {
            _comment.Delete(id);
        }

        public List<VehicleCommentDto> GetAll()
        {
            var comment = _comment.GetAll();
            var list = _mapper.Map<List<VehicleCommentDto>>(comment);
            return list;
        }

        public VehicleCommentDto GetById(int id)
        {
            if (id > 0)
            {
                var comment = _comment.GetByID(id);
                var commentId = _mapper.Map<VehicleCommentDto>(comment);
                return commentId;
            }

            throw new Exception("Id can not be less then 1");
        }

        public VehicleCommentDto Update(VehicleCommentDto entity)
        {
            entity.UpdateDate = DateTime.Now;
            var update = _comment.Update(_mapper.Map<VehicleComment>(entity));
            var send = _mapper.Map<VehicleCommentDto>(update);
            return send;
        }
    }
}
