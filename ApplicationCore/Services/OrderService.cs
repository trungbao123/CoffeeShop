using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public OrderDto GetOrder(int orderId)
        {
            var order = _unitOfWork.Orders.GetBy(orderId);
            return _mapper.Map<Order, OrderDto>(order);
        }

        public int getIDod()
        {
            return _unitOfWork.Orders.getIDod();
        }
        public IEnumerable<OrderDto> GetOrders(string userName)
        {
            Expression<Func<Order, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(userName))
            {
                predicate = m => m.UserNv.Contains(userName);
            }

            var orders = _unitOfWork.Orders.Find(predicate);

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        }

        public IEnumerable<string> GetUsers()
        {
            return _unitOfWork.Orders.GetUsers();
        }

        public void CreateOrder(SaveOrderDto saveOrderDto)
        {
            var order = _mapper.Map<SaveOrderDto, Order>(saveOrderDto);
            _unitOfWork.Orders.Add(order);

            _unitOfWork.Complete();
        }

        public void UpdateOrder(SaveOrderDto saveOrderDto)
        {
            var order = _unitOfWork.Orders.GetBy(saveOrderDto.OrderId);
            if (order == null) return;

            _mapper.Map<SaveOrderDto, Order>(saveOrderDto, order);

            _unitOfWork.Complete();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _unitOfWork.Orders.GetBy(orderId);
            if (order != null)
            {
                _unitOfWork.Orders.Remove(order);
                _unitOfWork.Complete();
            }
        }
    }
}