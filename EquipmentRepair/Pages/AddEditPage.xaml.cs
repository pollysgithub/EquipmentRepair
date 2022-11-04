using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EquipmentRepair.DataBase;


namespace EquipmentRepair.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Technic _currentTechnic = new Technic();

        public AddEditPage(Technic selectedTechnic)
        {
            InitializeComponent();

            if (selectedTechnic != null)
                _currentTechnic = selectedTechnic;

            
            DataContext = _currentTechnic;
            ComboDivisionName.ItemsSource = EquipmentRepairEntities.GetContext().Divisions.ToList();
            List<Employee> listEmployees = EquipmentRepairEntities.GetContext().Employees.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (Convert.ToString(_currentTechnic.InventoryNumber) == null)
                errors.AppendLine("Укажите инвентарный номер.");
            if (Convert.ToString(_currentTechnic.YearOfIssue) == null)
                errors.AppendLine("Укажите год производства.");
            if (_currentTechnic.TechnicName == null)
                errors.AppendLine("Укажите название техниеи.");
            if (_currentTechnic.Model == null)
                errors.AppendLine("Укажите ветеринара.");
            if (_currentTechnic.Division == null)
                errors.AppendLine("Укажите подразделение.");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentTechnic.DivisionId == 0)
                EquipmentRepairEntities.GetContext().Technics.Add(_currentTechnic);

            try
            {
                EquipmentRepairEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
   
