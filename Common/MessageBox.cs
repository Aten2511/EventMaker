using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace EventMaker.Common
{
    class MessageBox
    {
        //fdsfjfgfhkfgf
        public static async void Show(string content)
        {
            var dialog = new MessageDialog(content);
            //dialog.Title = title;
            dialog.Commands.Add(new UICommand("Ok") { Id = 0 });
            dialog.DefaultCommandIndex = 0;

            await dialog.ShowAsync();

            //var messageDialog = new ContentDialog();
            //messageDialog.Content = content;
            //messageDialog.Title = title;
            //messageDialog.PrimaryButtonText = "Ok";
            //messageDialog.Hide();
            //await messageDialog.ShowAsync();

        }
    }
}
