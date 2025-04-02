using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OvO.Data;
using OvO.Models;

namespace OvO.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private readonly TodoDatabase _database;

        [ObservableProperty]
        private ObservableCollection<TodoItem> todoItems;

        [ObservableProperty]
        private string newTaskTitle;

        public MainViewModel()
        {
            _database = new TodoDatabase();
            LoadItems();
        }

        //подгружaем все элементы таблицыв на странице
        [RelayCommand]
        private async void LoadItems()
        {
            var items = await _database.GetItems();
            TodoItems = new ObservableCollection<TodoItem>(items);
        }

        [RelayCommand]
        private async void AddItem()
        {
            if (!string.IsNullOrEmpty(NewTaskTitle))
            {
                var newItem = new TodoItem { Title = NewTaskTitle, IsCompleted = false };
                await _database.SaveItem(newItem);
                NewTaskTitle = "";
                LoadItems();
            }
        }

        [RelayCommand]
        private async void DeleteItem(TodoItem item)
        {
            await _database.DeleteItem(item);
            LoadItems();
        }

    }
}
