using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DapperExtensions.Sql;

namespace DapperExtensions.Tests.Helpers
{
    public class DatabaseInfo
    {
        public IDbConnection Connection { get; set; }
        public ISqlDialect Dialect { get; set; }
    }
}