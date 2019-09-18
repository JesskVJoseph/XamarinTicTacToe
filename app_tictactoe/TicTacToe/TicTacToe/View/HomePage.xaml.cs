using Xamarin.Forms;

namespace TicTacToe.View
{
    public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new HomeViewModel(this);
		}
	}
}
