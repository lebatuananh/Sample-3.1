using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Postgre.Dao.Interfaces;
using Api.Data.Postgre.Dto;
using Base.Data.Postgre;
using Base.Data.Postgre.Dao;

namespace Api.Data.Postgre.Dao
{
    public class CustomerDao : BasePostgreDao<CustomerDto>, ICustomerDao
    {
        public CustomerDao(IDatabaseSelector dbSelector) : base(dbSelector)
        {

        }
    }
}
