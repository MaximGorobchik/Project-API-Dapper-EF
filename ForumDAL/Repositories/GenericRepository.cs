using Dapper;
using ReportService.Repositories.Interfaces;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ReportService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        private readonly string _tableName;

        public GenericRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction, string tableName)
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
            _tableName = tableName;
        }

        // Отримати всі об'єкти з таблиці
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _sqlConnection.QueryAsync<T>($"SELECT * FROM {_tableName}", transaction: _dbTransaction);
        }


        // Отримати об'єкт за його ідентифікатором
        public async Task<T> GetByIdAsync(int id)
        {
            return await _sqlConnection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE ID = @Id", new { Id = id }, transaction: _dbTransaction);
        }

        // Видалити об'єкт за його ідентифікатором
        public async Task<int> DeleteAsync(int id)
        {
            int deleted = await _sqlConnection.ExecuteAsync($"DELETE FROM {_tableName} WHERE ID = @Id", new { Id = id }, transaction: _dbTransaction);
            return deleted;
        }

        // Додати новий об'єкт до таблиці та повернути його ідентифікатор
        public async Task<int> AddAsync(T t)
        {
            var insertQuery = GenerateInsertQuery();
            var newId = await _sqlConnection.ExecuteScalarAsync<int>(insertQuery,
                param: t,
                transaction: _dbTransaction);
            return newId;
        }

        // Оновити існуючий об'єкт в таблиці
        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();
            await _sqlConnection.ExecuteAsync(updateQuery,
                param: t,
                transaction: _dbTransaction);
        }

        // Робота з властивостями моделі

        // Отримати список властивостей моделі
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        // Згенерувати список властивостей моделі, які будуть використовуватись в SQL-запитах
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        // Генерувати SQL-запит для вставки об'єкта в таблицю
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");
            insertQuery.Append("(");
            var properties = GenerateListOfProperties(GetProperties);
            // У випадку, якщо рядок-ключ (PK) є автоінкрементним, видаляємо його зі списку властивостей
            properties.Remove("Id");
            //
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");
            insertQuery.Append("; SELECT SCOPE_IDENTITY()");
            return insertQuery.ToString();
        }

        // Генерувати SQL-запит для оновлення об'єкта в таблиці
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");
            return updateQuery.ToString();
        }
    }
}
