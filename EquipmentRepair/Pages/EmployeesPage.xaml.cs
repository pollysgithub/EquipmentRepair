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
using Word = Microsoft.Office.Interop.Word;

namespace EquipmentRepair.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentRepairEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridEmployees.ItemsSource = EquipmentRepairEntities.GetContext().Employees.ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> allEmployees = EquipmentRepairEntities.GetContext().Employees.ToList();
                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table employeessTable = document.Tables.Add(tableRange, allEmployees.Count + 1, 8);
                employeessTable.Borders.InsideLineStyle = employeessTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                employeessTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = employeessTable.Cell(1, 1).Range;
                cellRange.Text = "Номер работника";
                cellRange = employeessTable.Cell(1, 2).Range;
                cellRange.Text = "Дата начала работы";
                cellRange = employeessTable.Cell(1, 3).Range;
                cellRange.Text = "Дата окончания работы";
                cellRange = employeessTable.Cell(1, 4).Range;
                cellRange.Text = "Фамилия";
                cellRange = employeessTable.Cell(1, 5).Range;
                cellRange.Text = "Имя";
                cellRange = employeessTable.Cell(1, 6).Range;
                cellRange.Text = "Отчество";
                cellRange = employeessTable.Cell(1, 7).Range;
                cellRange.Text = "Подразделение";
                cellRange = employeessTable.Cell(1, 8).Range;
                cellRange.Text = "должность";
                employeessTable.Rows[1].Range.Bold = 1;
                employeessTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int i = 1;
                foreach (var currentEmployee in allEmployees)
                {
                    cellRange = employeessTable.Cell(i + 1, 1).Range;
                    cellRange.Text = currentEmployee.EmployeeId.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 2).Range;
                    cellRange.Text = currentEmployee.StartWorkingDate.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 3).Range;
                    cellRange.Text = currentEmployee.EndWorkingDate.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 4).Range;
                    cellRange.Text = currentEmployee.LastName.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 5).Range;
                    cellRange.Text = currentEmployee.FirstName;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 6).Range;
                    cellRange.Text = currentEmployee.MiddleName;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 7).Range;
                    cellRange.Text = currentEmployee.Division.DivisionName;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 8).Range;
                    cellRange.Text = currentEmployee.Post.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                app.Visible = true;
                document.SaveAs2(@"C:\Users\Анна\Desktop\практика Поля\outputFilePdf.pdf", Word.WdExportFormat.wdExportFormatPDF);
            }
            catch
            {
                MessageBox.Show("Шо-то не так");
            }
        }
    }
}
