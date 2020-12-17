using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class DetailOrderService : IDetailOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetailOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public DetailOrderDto GetDetailOrder(int detailOrderId)
        {
            var detailOrder = _unitOfWork.DetailOrders.GetBy(detailOrderId);
            return _mapper.Map<DetailOrder, DetailOrderDto>(detailOrder);
        }

        public IEnumerable<DetailOrderDto> GetDetailOrders(string MenuName)
        {
            Expression<Func<DetailOrder, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(MenuName))
            {
                predicate = m => m.MenuName.Contains(MenuName);
            }

            var detailorders = _unitOfWork.DetailOrders.Find(predicate);

            return _mapper.Map<IEnumerable<DetailOrder>, IEnumerable<DetailOrderDto>>(detailorders);
        }

        public IEnumerable<string> GetMenuNames()
        {
            return _unitOfWork.DetailOrders.GetMenuNames();
        }

        public void CreateDetailOrder(SaveDetailOrderDto saveDetailOrderDto)
        {
            var detailorder = _mapper.Map<SaveDetailOrderDto, DetailOrder>(saveDetailOrderDto);
            _unitOfWork.DetailOrders.Add(detailorder);

            _unitOfWork.Complete();
        }

        public void UpdateDetailOrder(SaveDetailOrderDto saveDetailOrderDto)
        {
            var detailorder = _unitOfWork.DetailOrders.GetBy(saveDetailOrderDto.DetailOrderId);
            if (detailorder == null) return;

            _mapper.Map<SaveDetailOrderDto, DetailOrder>(saveDetailOrderDto, detailorder);

            _unitOfWork.Complete();
        }

        public void DeleteDetailOrder(int detailorderId)
        {
            var detailorder = _unitOfWork.DetailOrders.GetBy(detailorderId);
            if (detailorder != null)
            {
                _unitOfWork.DetailOrders.Remove(detailorder);
                _unitOfWork.Complete();
            }
        }
    }
}