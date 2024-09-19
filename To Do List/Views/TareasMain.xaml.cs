using To_Do_List.ViewModels;

namespace To_Do_List.Views;

public partial class TareasMain : ContentPage
{
	private TareasMainViewModel viewModel;
	public TareasMain()
	{
		InitializeComponent();
		viewModel = new TareasMainViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}