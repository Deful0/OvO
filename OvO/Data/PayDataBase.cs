using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OvO.Models;
using SQLite;

namespace OvO.Data
{
    class PayDataBase
    {

        private readonly SQLiteAsyncConnection _connection;

        public PayDataBase()
        {
            //Открываю файл с бд (Pay.db)
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Pay.db");
            //передаю путь
            _connection = new SQLiteAsyncConnection(dbPath);
            //создаю табшлицу в БД на основе TodoItem
            _connection.CreateTableAsync<TodoPay>().Wait();
        }

        //метлод для вывода таблицы
        public Task<List<TodoPay>> GetItems()
        {
            return _connection.Table<TodoPay>().ToListAsync();
        }

        //добавление/обновление строк
        public Task<int> SaveItem(TodoPay item)
        {
            if (item.Id == 0)
            {
                return _connection.InsertAsync(item);
            }
            else
            {
                return _connection.UpdateAsync(item);
            }
        }

        // Удаление строк
        public Task<int> DeleteItem(TodoPay item)
        {
            return _connection.DeleteAsync(item);
        }

    }
}
