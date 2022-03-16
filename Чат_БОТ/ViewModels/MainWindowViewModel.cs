using System.Data;
using System.Windows.Input;
using Чат_БОТ.ViewModels.Base;
using Чат_БОТ.Commands;

namespace Чат_БОТ.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Таблицы сообщений : DataTable

        private DataTable _table2;

        /// <summary>Table</summary>
        public DataTable table2
        {
            get => _table2;
            set => Set(ref _table2, value);
        }

        public DataTable table = new DataTable("MessengeTable");
        DataColumn column;
        DataRow row;

        #endregion

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
            row["Messange"] = "Привет";
            row["Access"] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Messange"] = "Привет солнышко)";
            row["Access"] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Messange"] = "Как у тебя дела?";
            row["Access"] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Messange"] = "Все супер, я же бот. А как у тебя дела?";
            row["Access"] = false;
            table.Rows.Add(row);

            table2 = table;
        }

        #endregion

        #endregion

        /*------------------------------------------------------------------------------------------------*/
        public MainWindowViewModel()
        {
            #region Команды

            SendTask = new LamdaCommand(OnSendTaskExecuted, CanSendTaskExecute);

            #endregion

            #region Создание колонок таблицы table

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Messange";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);
            
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "Access";
            column.ReadOnly = true;
            column.Unique = false;
            table.Columns.Add(column);

            #endregion
        }
    }
}