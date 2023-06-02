using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void window_loaded(object sender, RoutedEventArgs e)
        {
            filldatagrid();
        }

        async void filldatagrid()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync("https:localhost:5001/api/departments");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonstring = await httpResponseMessage.Content.ReadAsStringAsync();
                    List<Department> list = JsonConvert.DeserializeObject<List<Department>>(jsonstring);
                    gridDepartment.ItemsSource = list;
                    MessageBox.Show("Success");
                }
                else
                    MessageBox.Show("API Error");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPage page = new DepartmentPage();
            this.Visibility = Visibility.Hidden;
            page.ShowDialog();
            filldatagrid();
            this.Visibility = Visibility.Visible;
        }

        Department department = new Department();
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (department != null)
            {
                MessageBox.Show("Select a department from table");
            }
            else
            {
                DepartmentPage page = new DepartmentPage();
                this.Visibility = Visibility.Hidden;
                page.department = department;
                this.Visibility = Visibility.Visible;
                filldatagrid();
            }
        }

        private void gridDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            department = (Department)gridDepartment.SelectedItem;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (department == null)
                MessageBox.Show("Please select a department from table");
            else
            {
                if (MessageBox.Show("Are you sure to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:5001/api/departments/" + department.Id);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Department was deleted");
                            filldatagrid();
                        }
                        else
                            MessageBox.Show("Not found");
                    }
                }
            }
        }
    }
}
