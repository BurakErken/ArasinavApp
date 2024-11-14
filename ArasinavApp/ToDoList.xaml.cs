using System.Collections.ObjectModel;
using ArasinavApp.Model;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace ArasinavApp;

public partial class ToDoList : ContentPage
{
    public ToDoList()
    {
        InitializeComponent();
        ctrlTodoList.ItemsSource = ListTodo;
    }

    public ObservableCollection<ToDo> ListTodo { get; set; } =
        new ObservableCollection<ToDo> {
    
        };

    private async void AddTodo_Click(object sender, EventArgs e)
    {
        var res = await DisplayPromptAsync("G�rev Ekle", "Yap�lacak:", "OK", placeholder: "yap�lacaklar� buraya yaz");
        
        if (res != null)
        {
            ToDo todo = new ToDo() { Image = "list.png", Text = res, IsDone = false };
            ListTodo.Add(todo);
        }
    }

    private async void DeleteTodo_Click(object sender, EventArgs e)
    {
        var todo = ListTodo.First(o => o.ID == (sender as MenuItem).CommandParameter.ToString());

        var res = await DisplayAlert("Silmeyi onayla", "Silinsin mi?", "Evet", "Hay�r");

        if (res == true)
        {
            ListTodo.Remove(todo);
        }

    }

    private async void EditTodo_Click(object sender, EventArgs e)
    {
        var todo = ListTodo.First(o => o.ID == (sender as MenuItem).CommandParameter.ToString());

        if (todo != null)
        {
            var res = await DisplayPromptAsync("D�zenle", "Yap�lacak:", initialValue: todo.Text, placeholder: "yap�lacaklar� buraya yaz");

            if (res != null) 
            {
                todo.Text = res; 
            }
        }
    }

    private async void ImageTodo_Click(object sender, EventArgs e)
    {
        var todo = ListTodo.First(o => o.ID == (sender as MenuItem).CommandParameter.ToString());
        var res = await DisplayActionSheet("Resim Se�", null, null, "Galeri", "Kamera");
        if (res == "Galeri")
        {

            var resim = await MediaPicker.Default.PickPhotoAsync();
            todo.Image = resim.FullPath;

        }
        else if (res == "Kamera")
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                var resim = await MediaPicker.Default.CapturePhotoAsync();
                todo.Image = resim.FullPath;
            }

        }


    }
}