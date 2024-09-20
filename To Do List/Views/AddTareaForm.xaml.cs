namespace To_Do_List.Views;
using To_Do_List.Models;
using To_Do_List.ViewModels;

public partial class AddTareaForm : ContentPage
{
	private AddTareaFormViewModel viewModel;
	public AddTareaForm()
    {
        InitializeComponent();
		viewModel = new AddTareaFormViewModel();
		BindingContext = viewModel;


    }

	public AddTareaForm(Tareas tareas)
	{
		InitializeComponent();
        viewModel = new AddTareaFormViewModel(tareas);
        BindingContext = viewModel;
    }
}