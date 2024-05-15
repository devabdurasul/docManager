namespace DocManager
{
    public partial class UsersPage : ContentPage
    {

        public UsersPage()
        {
            InitializeComponent();
            this.BindingContext = new UsersPageViewModel();
        }

        private void DepartmentListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Department selectedDepartment)
            {
                var departmentDetailPage = new DepartmentDetailPage();
                departmentDetailPage.Department = selectedDepartment;
                departmentDetailPage.Init();
                Navigation.PushAsync(departmentDetailPage);
            }
        }
    }
}
