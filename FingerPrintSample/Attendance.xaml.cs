using FingerPrintSample.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FingerPrintSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Attend : ContentPage
    {
       
        
        public Attend()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            lbldateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            
        }

        
    }
}