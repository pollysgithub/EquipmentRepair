using EquipmentRepair.DataBase;
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

namespace EquipmentRepair.Pages
{
    /// <summary>
    /// Логика взаимодействия для TechnicPage.xaml
    /// </summary>
    public partial class TechnicPage : Page
    {
        public TechnicPage()
        {
            InitializeComponent();
        }
        
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentRepairEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridTechnic.ItemsSource = EquipmentRepairEntities.GetContext().Technics.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Technic));

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var petsForRemoving = DGridTechnic.SelectedItems.Cast<Technic>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {petsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentRepairEntities.GetContext().Technics.RemoveRange(petsForRemoving);
                    EquipmentRepairEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridTechnic.ItemsSource = EquipmentRepairEntities.GetContext().Technics.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
