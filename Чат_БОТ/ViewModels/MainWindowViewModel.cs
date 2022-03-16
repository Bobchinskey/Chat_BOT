using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Чат_БОТ.ViewModels.Base;
using Чат_БОТ.Commands;
using System.Data.SqlClient;
using System.Configuration;
using Чат_БОТ.Models;
using System.Windows;

namespace Чат_БОТ.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private DataTable _table2;

        /// <summary>NameBot</summary>
        public DataTable table2
        {
            get => _table2;
            set => Set(ref _table2, value);
        }

        public DataTable table = new DataTable("MessengeTable");
        DataColumn column;
        DataRow row;
        

        #region Имя Бота : NameBot

        private string _NameBot = "Чат бот";

        /// <summary>NameBot</summary>
        public string NameBot
        {
            get => _NameBot;
            set => Set(ref _NameBot, value);
        }

        #endregion
    

        /*------------------------------------------------------------------------------------------------*/

        #region Команды

        #region Команда авторизации пользователя

        public ICommand SendTask { get; }

        private bool CanSendTaskExecute(object p) => true;

        private void OnSendTaskExecuted(object p)
        {
            row = table.NewRow();
            row["Messange"] = "Привет солнышко)";
            row["Access"] = true;
            table.Rows.Add(row);
            table2 = table;
        }

        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Команды

            SendTask = new LamdaCommand(OnSendTaskExecuted, CanSendTaskExecute);

            #endregion


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Messange";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "Access";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
        }
    }
}