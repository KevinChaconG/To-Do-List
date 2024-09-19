namespace To_Do_List.Views;
using To_Do_List.Models;

public partial class AddTareaForm : ContentPage
{
	public AddTareaForm()
    {
        InitializeComponent();
    }

	public AddTareaForm(Tareas tareas)
	{
		InitializeComponent();
	}
}