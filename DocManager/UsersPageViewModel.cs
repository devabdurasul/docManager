using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DocManager
{
    public class UsersPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterUsers();
                }
            }
        }
        private ObservableCollection<User> _filteredUsers;
        public ObservableCollection<User> FilteredUsers
        {
            get { return _filteredUsers; }
            set
            {
                _filteredUsers = value;
                OnPropertyChanged();
            }
        }

        private void FilterUsers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredDepartmentUsers = new ObservableCollection<Department>(DepartmentUsers);
                FilteredEmployeeUsers = new ObservableCollection<Employee>(EmployeeUsers);
                return;
            }

            FilteredDepartmentUsers = new ObservableCollection<Department>(DepartmentUsers.Where(department => (department.OperatorName.Contains(SearchText) || department.Name.Contains(SearchText))));
            FilteredEmployeeUsers = new ObservableCollection<Employee>(EmployeeUsers.Where(employee => employee.Name.Contains(SearchText)));
        }

        private ObservableCollection<Department> _filteredDepartmentUsers;
        public ObservableCollection<Department> FilteredDepartmentUsers
        {
            get { return _filteredDepartmentUsers; }
            set
            {
                _filteredDepartmentUsers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> _filteredEmployeeUsers;
        public ObservableCollection<Employee> FilteredEmployeeUsers
        {
            get { return _filteredEmployeeUsers; }
            set
            {
                _filteredEmployeeUsers = value;
                OnPropertyChanged();
            }
        }

        public UsersPageViewModel()
        {
            AdminUsers = new ObservableCollection<User>
            {
                new User { Name = "Санҷар Ахмедов", Role = "Мудир" },
                new User { Name = "Абдурасул Исоқов", Role = "Мудир" },
                new User { Name = "Олга Ҳакимова", Role = "Мудир" },
                new User { Name = "Ораста Мирдадоева", Role = "Мудир" },
                new User { Name = "Дурдона Узоқова", Role = "Мудир" }
            };

            DepartmentUsers = new ObservableCollection<Department>
            {
                new Department { Name = "Маркетинг", OperatorName = "Санҷар Ахмедов", Role = "Кадрҳои Идора", Description = "Масъулият дар бораи ташкилоти маркетинг ва таҷвизҳо." },
                new Department { Name = "Молия", OperatorName = "Абдурасул Исоқо", Role = "Кадрҳои Идора", Description = "Масъулият дар бораи амалиёти молия ва бюджеткунӣ." },
                new Department { Name = "Вазорати кадрҳо", OperatorName = "Олга Ҳакимова", Role = "Кадрҳои Идора", Description = "Масъулият дар бораи мудирияти вазорати кадрҳо ва муносиботҳои кормандон." },
                new Department { Name = "Амалиётҳо", OperatorName = "Ораста Мирдадоева", Role = "Кадрҳои Идора", Description = "Масъулият дар бораи фаъолиятҳои амалиётӣ ва логистика." },
                new Department { Name = "ИТ", OperatorName = "Дурдона Узоқова", Role = "Кадрҳои Идора", Description = "Масъулият дар бораи мудирияти бунёди ИТ ва системаҳо." }
            };

            EmployeeUsers = new ObservableCollection<Employee>
            {
                new Employee { Name = "Дониёр Ниёзов", Department = "Маркетинг", Role = "Корманд" },
                new Employee { Name = "Боҳирҷон Ахмедов", Department = "Молия", Role = "Корманд" },
                new Employee { Name = "Ораста Мирдадоева", Department = "Вазорати кадрҳо", Role = "Корманд" },
                new Employee { Name = "Олга Ҳакимова", Department = "Амалиётҳо", Role = "Корманд" },
                new Employee { Name = "Александр Кларк", Department = "ИТ", Role = "Корманд" }
            };


            FilteredDepartmentUsers = DepartmentUsers;
            FilteredEmployeeUsers = EmployeeUsers;
        }

        private ObservableCollection<User> _adminUsers;
        public ObservableCollection<User> AdminUsers
        {
            get { return _adminUsers; }
            set
            {
                _adminUsers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Department> _departmentUsers;
        public ObservableCollection<Department> DepartmentUsers
        {
            get { return _departmentUsers; }
            set
            {
                _departmentUsers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> _employeeUsers;
        public ObservableCollection<Employee> EmployeeUsers
        {
            get { return _employeeUsers; }
            set
            {
                _employeeUsers = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class Department
    {
        public string OperatorName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
    }
}