using Catering.Attributes;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class ExportToExcelCustomerCommand<TModel,TviewModel> : BaseControlCommand<TviewModel> where TviewModel : BaseControlViewModel where TModel : BaseControlModel
    {
        public ExportToExcelCustomerCommand(TviewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            DataTable exportTable = new DataTable();

            List<PropertyInfo> props = new List<PropertyInfo>();
            var properties = typeof(TModel).GetProperties();
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

            ObservableCollection<TModel> list = null;


            //var vmstringname = "ControlViewModel";
            //var Name = viewModel.GetType().ToString();
            //Name = Name.Remove(0, 36);
            //Name = Name.Remove(Name.IndexOf(vmstringname), vmstringname.Length);
            //Name = Name + "s";
            //var props1 = viewModel.GetType().GetProperties();

            //foreach (var item in props1)
            //{
            //    if (item.Name == Name)
            //    {
            //        var q = item.PropertyType;
            //        list = (ObservableCollection<TModel>)item.GetValue(viewModel);
            //        break;
            //    }
            //}


            list = viewModel.GetType().GetProperties().FirstOrDefault(x => x.PropertyType == typeof(ObservableCollection<TModel>))
                                                      .GetValue(viewModel) as ObservableCollection<TModel>;


            foreach (var item in list)
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
                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    xlb.SaveAs(saveFileDialog.FileName);

                
            }
        }
    }
}
