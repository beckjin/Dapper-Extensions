using System.Collections.Generic;

namespace DapperExtensions.Sql
{
    public class DamengDialect : SqlDialectBase
    {
        public override string GetIdentitySql(string tableName)
        {
            return $"SELECT IDENT_CURRENT('{tableName.Replace("\"", string.Empty)}') AS ID";
        }

        public override string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            int startValue = page * resultsPerPage;
            return GetSetSql(sql, startValue, resultsPerPage, parameters);
        }

        public override string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            string result = string.Format("{0} LIMIT :firstResult, :maxResults", sql);
            parameters.Add(":firstResult", firstResult);
            parameters.Add(":maxResults", maxResults);
            return result;
        }

        public override string GetLimitCountSql(string column, string tableName, string where, string orderBy, int count, IDictionary<string, object> parameters)
        {
            string result = string.Format("SELECT {0} FROM {1} {2} {3} LIMIT :count", column, tableName, where, orderBy);
            parameters.Add(":count", count);
            return result;
        }
        public override char ParameterPrefix
        {
            get { return ':'; }
        }

        public override string GetColumnName(string prefix, string columnName, string alias)
        {
            return base.GetColumnName(null, columnName, alias);
        }

        public override bool SupportsMultipleStatements => false;
    }
}
