using MedsManager.Pages;

namespace MedsManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("medicine/details", typeof(MedicineDetailsPage));
        }
    }
}
