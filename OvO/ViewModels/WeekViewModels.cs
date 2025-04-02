using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OvO.Data;
using OvO.Models;

namespace OvO.ViewModels
{
    public partial class WeekViewModels : ObservableObject
    {

        private readonly WeekDataBase _database;

        [ObservableProperty]
        private ObservableCollection<TodoWeek> todoWeek;

        [ObservableProperty]
        private string newTaskTitle2;

        public WeekViewModels()
        {
            _database = new WeekDataBase();
            LoadItems2();
        }

        //подгружaем все элементы таблицыв на странице
        [RelayCommand]
        private async void LoadItems2()
        {
            var items = await _database.GetItems();
            TodoWeek = new ObservableCollection<TodoWeek>(items);
        }

        [RelayCommand]
        private async void AddItem2()
        {
            if (!string.IsNullOrEmpty(NewTaskTitle2))
            {
                var newItem = new TodoWeek { Title2 = NewTaskTitle2, IsCompleted = false };
                await _database.SaveItem(newItem);
                NewTaskTitle2 = "";
                LoadItems2();
            }
        }

        [RelayCommand]
        private async void DeleteItem2(TodoWeek item)
        {
            await _database.DeleteItem(item);
            LoadItems2();
        }

    }
}
