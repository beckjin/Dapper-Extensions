using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperExtensions
{
    public interface IDatabase : IDisposable
    {
        bool HasActiveTransaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();

        #region Sync

        void RunInTransaction(Action action);
        T RunInTransaction<T>(Func<T> func);
        T Get<T>(dynamic id, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        T Get<T>(dynamic id, int? commandTimeout = null) where T : class;
        T GetOne<T>(IDbTransaction transaction, object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class;
        T GetOne<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class;
        int Insert<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        int Insert<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class;
        dynamic Insert<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        dynamic Insert<T>(T entity, int? commandTimeout = null) where T : class;
        int Update<T>(T entity, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        int Update<T>(T entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        int Update<T>(T entity, object predicate, List<string> updateFileds, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        int Update<T>(T entity, object predicate, List<string> updateFileds, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        int Delete<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        int Delete<T>(T entity, int? commandTimeout = null) where T : class;
        int Delete<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        int Delete<T>(object predicate, int? commandTimeout = null) where T : class;
        IEnumerable<T> GetList<T>(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetList<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetList<T>(int limitCount, object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetList<T>(int limitCount, object predicate, IList<ISort> sort, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout = null, bool buffered = true) where T : class;
        int Count<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        int Count<T>(object predicate, int? commandTimeout = null) where T : class;
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null);
        IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, int? commandTimeout = null);

        #endregion

        #region Async

        Task RunInTransactionAsync(Func<Task> action);
        Task<T> RunInTransactionAsync<T>(Func<Task<T>> func);

        Task<T> GetAsync<T>(dynamic id, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<T> GetAsync<T>(dynamic id, int? commandTimeout = null) where T : class;
        Task<T> GetOneAsync<T>(IDbTransaction transaction, object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class;
        Task<T> GetOneAsync<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class;
        Task<int> InsertAsync<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<int> InsertAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class;
        Task<dynamic> InsertAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class;
        Task<int> UpdateAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        Task<int> UpdateAsync<T>(T entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        Task<int> UpdateAsync<T>(T entity, object predicate, List<string> updateFileds, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        Task<int> UpdateAsync<T>(T entity, object predicate, List<string> updateFileds, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        Task<int> DeleteAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<int> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class;
        Task<int> DeleteAsync<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<int> DeleteAsync<T>(object predicate, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetListAsync<T>(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetListAsync<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetListAsync<T>(int limitCount, object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetListAsync<T>(int limitCount, object predicate, IList<ISort> sort, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetPageAsync<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetPageAsync<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null) where T : class;
        Task<IEnumerable<T>> GetSetAsync<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout) where T : class;
        Task<IEnumerable<T>> GetSetAsync<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout) where T : class;
        Task<int> CountAsync<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class;
        Task<int> CountAsync<T>(object predicate, int? commandTimeout = null) where T : class;
        Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null);
        Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, int? commandTimeout = null);

        #endregion

        void ClearCache();
        Guid GetNextGuid();
        IClassMapper GetMap<T>() where T : class;
    }

    public class Database : IDatabase
    {
        private readonly IDapperImplementor _dapper;

        private IDbTransaction _transaction;

        public Database(IDbConnection connection, ISqlGenerator sqlGenerator)
        {
            _dapper = new DapperImplementor(sqlGenerator);
            Connection = connection;

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public bool HasActiveTransaction
        {
            get
            {
                return _transaction != null;
            }
        }

        public IDbConnection Connection { get; private set; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }

                Connection.Close();
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        #region Sync

        public void RunInTransaction(Action action)
        {
            BeginTransaction();
            try
            {
                action();
                Commit();
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public T RunInTransaction<T>(Func<T> func)
        {
            BeginTransaction();
            try
            {
                T result = func();
                Commit();
                return result;
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public T Get<T>(dynamic id, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return (T)_dapper.Get<T>(Connection, id, transaction, commandTimeout);
        }

        public T Get<T>(dynamic id, int? commandTimeout = null) where T : class
        {
            return (T)_dapper.Get<T>(Connection, id, _transaction, commandTimeout);
        }

        public T GetOne<T>(IDbTransaction transaction, object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class
        {
            return _dapper.Get<T>(Connection, predicate, sort, transaction, commandTimeout, false);
        }

        public T GetOne<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class
        {
            return _dapper.Get<T>(Connection, predicate, sort, _transaction, commandTimeout, false);
        }

        public int Insert<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return _dapper.Insert<T>(Connection, entities, transaction, commandTimeout);
        }

        public int Insert<T>(IEnumerable<T> entities, int? commandTimeout) where T : class
        {
            return _dapper.Insert<T>(Connection, entities, _transaction, commandTimeout);
        }

        public dynamic Insert<T>(T entity, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return _dapper.Insert<T>(Connection, entity, transaction, commandTimeout);
        }

        public dynamic Insert<T>(T entity, int? commandTimeout) where T : class
        {
            return _dapper.Insert<T>(Connection, entity, _transaction, commandTimeout);
        }

        public int Update<T>(T entity, IDbTransaction transaction, int? commandTimeout, bool ignoreAllKeyProperties) where T : class
        {
            return _dapper.Update<T>(Connection, entity, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public int Update<T>(T entity, int? commandTimeout, bool ignoreAllKeyProperties) where T : class
        {
            return _dapper.Update<T>(Connection, entity, _transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public int Update<T>(T entity, object predicate, List<string> updateFileds, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return _dapper.Update<T>(Connection, entity, predicate, updateFileds, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public int Update<T>(T entity, object predicate, List<string> updateFileds, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return _dapper.Update<T>(Connection, entity, predicate, updateFileds, _transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public int Delete<T>(T entity, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return _dapper.Delete(Connection, entity, transaction, commandTimeout);
        }

        public int Delete<T>(T entity, int? commandTimeout) where T : class
        {
            return _dapper.Delete(Connection, entity, _transaction, commandTimeout);
        }

        public int Delete<T>(object predicate, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return _dapper.Delete<T>(Connection, predicate, transaction, commandTimeout);
        }

        public int Delete<T>(object predicate, int? commandTimeout) where T : class
        {
            return _dapper.Delete<T>(Connection, predicate, _transaction, commandTimeout);
        }

        public IEnumerable<T> GetList<T>(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetList<T>(Connection, predicate, sort, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetList<T>(object predicate, IList<ISort> sort, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetList<T>(Connection, predicate, sort, _transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetList<T>(int limitCount, object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return _dapper.GetList<T>(Connection, limitCount, predicate, sort, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetList<T>(int limitCount, object predicate, IList<ISort> sort, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return _dapper.GetList<T>(Connection, limitCount, predicate, sort, _transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetPage<T>(Connection, predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetPage<T>(Connection, predicate, sort, page, resultsPerPage, _transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetSet<T>(Connection, predicate, sort, firstResult, maxResults, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetSet<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout, bool buffered) where T : class
        {
            return _dapper.GetSet<T>(Connection, predicate, sort, firstResult, maxResults, _transaction, commandTimeout, buffered);
        }

        public int Count<T>(object predicate, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return _dapper.Count<T>(Connection, predicate, transaction, commandTimeout);
        }

        public int Count<T>(object predicate, int? commandTimeout) where T : class
        {
            return _dapper.Count<T>(Connection, predicate, _transaction, commandTimeout);
        }

        public IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout)
        {
            return _dapper.GetMultiple(Connection, predicate, transaction, commandTimeout);
        }

        public IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, int? commandTimeout)
        {
            return _dapper.GetMultiple(Connection, predicate, _transaction, commandTimeout);
        }

        #endregion

        #region Async

        public async Task RunInTransactionAsync(Func<Task> action)
        {
            BeginTransaction();
            try
            {
                await action();
                Commit();
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public async Task<T> RunInTransactionAsync<T>(Func<Task<T>> func)
        {
            BeginTransaction();
            try
            {
                T result = await func();
                Commit();
                return result;
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public async Task<T> GetAsync<T>(dynamic id, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetAsync<T>(Connection, id, transaction, commandTimeout);
        }

        public async Task<T> GetAsync<T>(dynamic id, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetAsync<T>(Connection, id, _transaction, commandTimeout);
        }

        public async Task<T> GetOneAsync<T>(IDbTransaction transaction, object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetAsync<T>(Connection, predicate, sort, transaction, commandTimeout);
        }

        public async Task<T> GetOneAsync<T>(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetAsync<T>(Connection, predicate, sort, _transaction, commandTimeout);
        }

        public async Task<int> InsertAsync<T>(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.InsertAsync<T>(Connection, entities, transaction, commandTimeout);
        }

        public async Task<int> InsertAsync<T>(IEnumerable<T> entities, int? commandTimeout = null) where T : class
        {
            return await _dapper.InsertAsync<T>(Connection, entities, _transaction, commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.Insert<T>(Connection, entity, transaction, commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await _dapper.InsertAsync<T>(Connection, entity, _transaction, commandTimeout);
        }

        public async Task<int> UpdateAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return await _dapper.UpdateAsync<T>(Connection, entity, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public async Task<int> UpdateAsync<T>(T entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return await _dapper.UpdateAsync<T>(Connection, entity, _transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public async Task<int> UpdateAsync<T>(T entity, object predicate, List<string> updateFileds, IDbTransaction transaction, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return await _dapper.UpdateAsync<T>(Connection, entity, predicate, updateFileds, transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public async Task<int> UpdateAsync<T>(T entity, object predicate, List<string> updateFileds, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return await _dapper.UpdateAsync<T>(Connection, entity, predicate, updateFileds, _transaction, commandTimeout, ignoreAllKeyProperties);
        }

        public async Task<int> DeleteAsync<T>(T entity, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.DeleteAsync(Connection, entity, transaction, commandTimeout);
        }

        public async Task<int> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await _dapper.DeleteAsync(Connection, entity, _transaction, commandTimeout);
        }

        public async Task<int> DeleteAsync<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.DeleteAsync<T>(Connection, predicate, transaction, commandTimeout);
        }

        public async Task<int> DeleteAsync<T>(object predicate, int? commandTimeout = null) where T : class
        {
            return await _dapper.DeleteAsync<T>(Connection, predicate, _transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(Connection, predicate, sort, transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(object predicate, IList<ISort> sort, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(Connection, predicate, sort, _transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(int limitCount, object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(Connection, limitCount, predicate, sort, transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(int limitCount, object predicate, IList<ISort> sort, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(Connection, limitCount, predicate, sort, _transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetPageAsync<T>(Connection, predicate, sort, page, resultsPerPage, transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetPageAsync<T>(Connection, predicate, sort, page, resultsPerPage, _transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetSetAsync<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetSetAsync<T>(Connection, predicate, sort, firstResult, maxResults, transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetSetAsync<T>(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetSetAsync<T>(Connection, predicate, sort, firstResult, maxResults, _transaction, commandTimeout);
        }

        public async Task<int> CountAsync<T>(object predicate, IDbTransaction transaction, int? commandTimeout = null) where T : class
        {
            return await _dapper.CountAsync<T>(Connection, predicate, transaction, commandTimeout);
        }

        public async Task<int> CountAsync<T>(object predicate, int? commandTimeout = null) where T : class
        {
            return await _dapper.CountAsync<T>(Connection, predicate, _transaction, commandTimeout);
        }

        public async Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return await _dapper.GetMultipleAsync(Connection, predicate, transaction, commandTimeout);
        }

        public async Task<IMultipleResultReader> GetMultipleAsync(GetMultiplePredicate predicate, int? commandTimeout = null)
        {
            return await _dapper.GetMultipleAsync(Connection, predicate, _transaction, commandTimeout);
        }

        #endregion

        public void ClearCache()
        {
            _dapper.SqlGenerator.Configuration.ClearCache();
        }

        public Guid GetNextGuid()
        {
            return _dapper.SqlGenerator.Configuration.GetNextGuid();
        }

        public IClassMapper GetMap<T>() where T : class
        {
            return _dapper.SqlGenerator.Configuration.GetMap<T>();
        }
    }
}