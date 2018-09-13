using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFPostsViewer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentsListPage : ContentPage
	{
		public CommentsListPage ()
		{
			InitializeComponent ();
		}
	}
}