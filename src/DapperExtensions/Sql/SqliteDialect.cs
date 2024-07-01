using System;
using System.Collections.Generic;
using System.Text;

namespace DapperExtensions.Sql
{
    public class SqliteDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName, string identityColumnName)
        {
            return "SELECT LAST_INSERT_ROWID() AS [Id]";
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            int startValue = page * resultsPerPage;
            return GetSetSql(sql, startValue, resultsPerPage, parameters);
        }

        public override string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException("SQL");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("Parameters");
            }

            var result = string.Format("{0} LIMIT @Offset, @Count", sql);
            parameters.Add("@Offset", firstResult);
            parameters.Add("@Count", maxResults);
            return result;
        }

        public override string GetLimitCountSql(string column, string tableName, string where, string orderBy, int count, IDictionary<string, object> parameters)
        {
            string result = string.Format("SELECT {0} FROM {1} {2} {3} LIMIT @Count", column, tableName, where, orderBy);
            parameters.Add("@Count", count);
            return result;
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(columnName, "columnName cannot be null or empty.");
            }
            var result = new StringBuilder();
            result.AppendFormat(columnName);
            if (!string.IsNullOrWhiteSpace(alias))
            {
                result.AppendFormat(" AS {0}", QuoteString(alias));
            }
            return result.ToString();
        }
    }
}
