using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using To_Do_List.Services;
using To_Do_List.Views;

namespace To_Do_List.ViewModels
{
    public partial class TareasMainViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Tareas> _tareasCollection = new ObservableCollection<Tareas>();

        private readonly TareaService TareaService;

        public TareasMainViewModel()
        {
            TareaService = new TareaService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = TareaService.GetAll();

            if(getAll.Count > 0)
            {
                _tareasCollection.Clear();
                foreach (var tarea in getAll)
                {
                    _tareasCollection.Add(tarea);
                }
            }
        }

        [RelayCommand]
        private async Task SelectTarea(Tareas tareas)
        {
            try
            {
                string actualizar = "Actualizar";
                string eliminar = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, actualizar, eliminar);

                if (res == actualizar)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddTareaForm(tareas));
                }
                else if(res == eliminar)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Tarea", "¿Desea eliminar esta tarea?", "Si", "No");

                    if (respuesta)
                    {
                        int del = TareaService.Delete(tareas);

                        if(del > 0)
                        {
                            _tareasCollection.Remove(tareas);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

        [RelayCommand]
        private async Task goToAddTareaForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddTareaForm());
        }

    }
}
