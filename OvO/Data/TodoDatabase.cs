using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OvO.Models;
using SQLite;

namespace OvO.Data
{
    class TodoDatabase
    {

        private readonly SQLiteAsyncConnection _connection;

        
        public TodoDatabase()
        {
            //Открываю файл с бд (Todo.db)
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Todo.db");
            //передаю путь
            _connection = new SQLiteAsyncConnection(dbPath);
            //создаю табшлицу в БД на основе TodoItem
            _connection.CreateTableAsync<TodoItem>().Wait();
        }

        //метлод для вывода таблицы
        public Task<List<TodoItem>> GetItems()
        {
            return _connection.Table<TodoItem>().ToListAsync();
        }

        //добавление/обновление строк
        public Task<int> SaveItem(TodoItem item)
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
        public Task<int> DeleteItem(TodoItem item)
        {
            return _connection.DeleteAsync(item);
        }

    }
}
