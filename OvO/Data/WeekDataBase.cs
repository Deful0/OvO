using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OvO.Models;
using SQLite;

namespace OvO.Data
{

    class WeekDataBase
    {
        private readonly SQLiteAsyncConnection _connection;

        public WeekDataBase()
        {
            //Открываю файл с бд (Week.db)
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Week.db");
            //передаю путь
            _connection = new SQLiteAsyncConnection(dbPath);
            //создаю табшлицу в БД на основе TodoItem
            _connection.CreateTableAsync<TodoWeek>().Wait();
        }

        //метлод для вывода таблицы
        public Task<List<TodoWeek>> GetItems()
        {
            return _connection.Table<TodoWeek>().ToListAsync();
        }

        //добавление/обновление строк
        public Task<int> SaveItem(TodoWeek item)
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
        public Task<int> DeleteItem(TodoWeek item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
