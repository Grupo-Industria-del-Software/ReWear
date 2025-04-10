﻿using Application.Interfaces.Specifications;
using Domain.AggregateRoots.Orders;
using Domain.Common;


namespace Application.Interfaces.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>>  GetAllByUserId(int userId, ISpecification<Order> spec);
        
        Task<IEnumerable<Order>>  GetAllByCustomerId(int userId, ISpecification<Order> spec);
        Task<Order?> GetByIdAsync(int orderId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task<bool> DeleteAsync(Order order);
        Task<IEnumerable<Order>> GetByFiltersAsync(int? customerId = null, int? providerId = null);
    }
}
