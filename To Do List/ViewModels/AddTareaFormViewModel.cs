using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using To_Do_List.Services;

namespace To_Do_List.ViewModels
{
    public partial class AddTareaFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string descripcion;

        [ObservableProperty]
        private string estado;

        [ObservableProperty]
        private string prioridad;

        private readonly TareaService TareaService;

        public List<string> Estados { get; } = new List<string>
        {
            "Pendiente", "En Proceso", "Completado"
        };

        public List<string> Prioridades { get; } = new List<string>
        {
            "Alta", "Media", "Baja"
        };

        [ObservableProperty]
        private string estadoSeleccionado;

        [ObservableProperty]
        private string prioridadSeleccionada;

        public AddTareaFormViewModel()
        {
            TareaService = new TareaService();
            estadoSeleccionado = "Pendiente";
            prioridadSeleccionada = "Baja";
        }

        public AddTareaFormViewModel(Tareas Tareas)
        {
            TareaService = new TareaService();
            id=Tareas.Id;
            nombre=Tareas.Nombre;
            descripcion=Tareas.Descripcion;
            estado=Tareas.Estado;
            prioridad=Tareas.Prioridad;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]

        private async Task AddUpdate()
        {
            try
            {
                Tareas Tareas = new Tareas
                {
                    Id = id,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Estado = estado,
                    Prioridad = prioridad,

                };

                if (Validar(Tareas))
                {
                    if (id == 0)
                    {
                        TareaService.Insert(Tareas);
                    }
                    else
                    {
                        TareaService.Update(Tareas);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }

            }catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            } 
        }

        private bool Validar(Tareas Tareas)
        {
            if(Tareas.Nombre == null || Tareas.Nombre == "")
            {
                Alerta("Advertencia", "Ingrese el nombre de la tarea");
                return false;
            } else
            {
                return true;
            }
        }
    }
}
