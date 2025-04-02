using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OvO.Data;
using OvO.Models;
using System.Collections.ObjectModel;

namespace OvO.ViewModels
{
    public partial class PayViewModel : ObservableObject
    {

        private readonly PayDataBase _database;

        [ObservableProperty]
        private ObservableCollection<TodoPay> todoPay;

        [ObservableProperty]
        private string newTaskTitle3;

        public PayViewModel()
        {
            _database = new PayDataBase();
            LoadItems3();
        }

        //подгружaем все элементы таблицыв на странице
        [RelayCommand]
        private async void LoadItems3()
        {
            var items = await _database.GetItems();
            TodoPay = new ObservableCollection<TodoPay>(items);
        }

        [RelayCommand]
        private async void AddItem3()
        {
            if (!string.IsNullOrEmpty(NewTaskTitle3))
            {
                var newItem = new TodoPay { Title3 = NewTaskTitle3, IsCompleted = false };
                await _database.SaveItem(newItem);
                NewTaskTitle3 = "";
                LoadItems3();
            }
        }

        [RelayCommand]
        private async void DeleteItem3(TodoPay item)
        {
            await _database.DeleteItem(item);
            LoadItems3();
        }

    }
}
