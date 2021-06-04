using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace BureauApp
{
    class ExportToXls
    {
        public static void ExportTable(DataGrid DG)
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            switch (MessageBox.Show("Экспортировать данную таблицу в MicrosoftExcel?", "Подтвердите действие", btnMessageBox))
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.DefaultExt = "*.xlsx";
                    saveFileDialog.ShowDialog();
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
                    switch (User.SelectedTable)
                    {
                        case "house":
                            ExportHouse(DG, sheet1);
                            break;
                        case "flat":
                            ExportFlat(DG, sheet1);
                            break;
                        case "room":
                            ExportDefault(DG, sheet1);
                            break;
                        case "users":
                            ExportDefault(DG, sheet1);
                            break;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);

                    excel.Quit();

                    MessageBox.Show("Файл успешно сохранен", "Успех");

                    break;

                case MessageBoxResult.No:
                    break;
            } 
        }
        public static void ExportTable(ReportWindows.Report window)
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            switch (MessageBox.Show("Экспортировать данную таблицу в MicrosoftExcel?", "Подтвердите действие", btnMessageBox))
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.DefaultExt = "*.xlsx";
                    saveFileDialog.ShowDialog();
                    Excel.Application excel = new Excel.Application();
                    excel.SheetsInNewWorkbook = 2;
                    Excel.Workbook workbook = excel.Workbooks.Add();
                    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
                    Excel.Worksheet sheet2 = (Excel.Worksheet)workbook.Sheets[2];

                    if (window.Flat_Grid.Visibility == Visibility.Hidden)
                    {
                        ExportHouse(window.DG_house, sheet1);
                    }
                    else
                    {
                        ExportFlat(window.DG_flat, sheet1);
                        ExportDefault(window.DG_room, sheet2);
                    }

                    workbook.SaveAs(saveFileDialog.FileName);

                    excel.Quit();

                    MessageBox.Show("Файл успешно сохранен", "Успех");

                    break;

                case MessageBoxResult.No:
                    break;
            }
        }
        private static void ExportHouse(DataGrid DG, Excel.Worksheet sheet)
        {


            for (int j = 0; j < DG.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                sheet.Cells[1, j + 1].Font.Bold = true;
                sheet.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DG.Columns[j].Header;
            }
            for (int i = 0; i < DG.Columns.Count; i++)
            {
                if (i == DG.Columns.Count - 1)
                {
                    for (int j = 0; j < DG.Items.Count; j++)
                    {
                        CheckBox b = DG.Columns[i].GetCellContent(DG.Items[j]) as CheckBox;
                        Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, DG.Columns.Count];
                        if (b.IsChecked == true) { myRange.Value2 = "Есть"; }
                        else myRange.Value2 = "Нет";
                    }
                }
                else
                {
                    for (int j = 0; j < DG.Items.Count; j++)
                    {

                        TextBlock b = DG.Columns[i].GetCellContent(DG.Items[j]) as TextBlock;
                        Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
            }         
        }
        private static void ExportFlat(DataGrid DG, Excel.Worksheet sheet)
        {

            for (int j = 0; j < DG.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                sheet.Cells[1, j + 1].Font.Bold = true;
                sheet.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DG.Columns[j].Header;
            }
            for (int i = 0; i < DG.Columns.Count; i++)
            {
                if (i == 5)
                {
                    for (int j = 0; j < DG.Items.Count; j++)
                    {
                        CheckBox b = DG.Columns[i].GetCellContent(DG.Items[j]) as CheckBox;
                        Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, DG.Columns.Count];
                        if (b.IsChecked == true) { myRange.Value2 = "Есть"; }
                        else myRange.Value2 = "Нет";
                    }
                }
                else
                {
                    for (int j = 0; j < DG.Items.Count; j++)
                    {

                    TextBlock b = DG.Columns[i].GetCellContent(DG.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                    } 
                }
            }
        }
        private static void ExportDefault(DataGrid DG, Excel.Worksheet sheet)
        {

            for (int j = 0; j < DG.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                sheet.Cells[1, j + 1].Font.Bold = true;
                sheet.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DG.Columns[j].Header;
            }
            for (int i = 0; i < DG.Columns.Count; i++)
            {
                for (int j = 0; j < DG.Items.Count; j++)
                {

                    TextBlock b = DG.Columns[i].GetCellContent(DG.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
        
    }
}
