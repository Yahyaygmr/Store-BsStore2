﻿using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IQueryable<Order> Orders => _repositoryManager.Order.Orders;

        public int NumberOfInProcess => _repositoryManager.Order.NumberOfInProcess;

        public void Complate(int id)
        {
            _repositoryManager.Order.Complate(id);
            _repositoryManager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _repositoryManager.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _repositoryManager.Order.SaveOrder(order);
            _repositoryManager.Save();
        }
    }
}
