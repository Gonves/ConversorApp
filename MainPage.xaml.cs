namespace ConversorApp
{
    public partial class MainPage : TabbedPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var w = selectDistancia.SelectedItem;
            var x = selectPeso.SelectedItem;
            var y = selectTemperatura.SelectedItem;
        }
         
   
    }

}
