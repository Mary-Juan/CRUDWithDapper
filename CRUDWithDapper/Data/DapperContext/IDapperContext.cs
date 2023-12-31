﻿using CRUDWithDapper.Models;
using Dapper;
using System.Data;

namespace CRUDWithDapper.Data.DapperContext
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
