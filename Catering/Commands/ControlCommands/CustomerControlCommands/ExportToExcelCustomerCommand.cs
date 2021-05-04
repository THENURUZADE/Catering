using Catering.Attributes;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class ExportToExcelCustomerCommand : BaseCustomerCommand
    {
        public ExportToExcelCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            DataTable exportTable = new DataTable();

            List<PropertyInfo> props = new List<PropertyInfo>();
            var properties = typeof(CustomerControlModel).GetProperties();
            foreach (var item in properties)
            {
                var att = item.GetCustomAttribute(typeof(ExportAttribute));
                var attribute = att as ExportAttribute;
                if (attribute != null)
                {
                    props.Add(item);
                    string name = attribute.Name;
                    exportTable.Columns.Add(name);
                }
            }
            foreach (var item in viewModel.Customers)
            {
                List<object> propValues = new List<object>(); 
                for (int i = 0; i < props.Count; i++)
                {
                    propValues.Add(props[i].GetValue(item));
                }
                exportTable.Rows.Add(propValues.ToArray());
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = "Məlumatlar",
            };
            saveFileDialog.ShowDialog();

            using (XLWorkbook xlb = new XLWorkbook())
            {
                xlb.Worksheets.Add(exportTable, "Melumatlar");
                xlb.Worksheet("Melumatlar").Rows().AdjustToContents();
                xlb.Worksheet("Melumatlar").Columns().AdjustToContents();
                xlb.SaveAs(saveFileDialog.FileName);
            }
        }
    }
}
