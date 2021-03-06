﻿using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IOrderDetailService : IService<OrderDetail>
    {
    }
    public class OrderDetailService
        : GenericService<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork db)
            : base(db) { }
    }
}
