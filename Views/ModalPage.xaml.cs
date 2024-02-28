namespace ShellLessonStep2.Views;

public partial class ModalPage : ContentPage
{
	public ModalPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.Navigation.PopModalAsync();
    }
}