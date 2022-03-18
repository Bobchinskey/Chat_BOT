using System.Data;
using System.Windows.Input;
using Чат_БОТ.ViewModels.Base;
using Чат_БОТ.Commands;
using System.Windows;
using System.Configuration;
using System.Data.SqlClient;

namespace Чат_БОТ.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public string Message;

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

        #region Сообщение пользователя : UserMessage

        private string _UserMessage;

        /// <summary>NameBot</summary>
        public string UserMessage
        {
            get => _UserMessage;
            set => Set(ref _UserMessage, value);
        }

        #endregion


        /*------------------------------------------------------------------------------------------------*/

        #region Команды

        #region Команда авторизации пользователя

        public ICommand SendTask { get; }

        private bool CanSendTaskExecute(object p) => true;

        private void OnSendTaskExecuted(object p)
        {
            if (UserMessage == null)
            {
                MessageBox.Show("Введите сообщение");   
            }
            else
            {
                if (UserMessage == "")
                {
                    row = table.NewRow();
                    row["Messange"] = UserMessage;
                    row["Access"] = true;
                    table.Rows.Add(row);

                    row = table.NewRow();
                    row["Messange"] = "Пустое сообщение? Мило)";
                    row["Access"] = false;
                    table.Rows.Add(row);

                    table2 = table;
                }
                else 
                { 
                    row = table.NewRow();
                    row["Messange"] = UserMessage;
                    row["Access"] = true;
                    table.Rows.Add(row);

                    string connectionString = ConfigurationManager.ConnectionStrings["Chat_Bot"].ConnectionString;
                    SqlConnection ThisConnection = new SqlConnection(connectionString);
                    ThisConnection.Open();
                    SqlCommand thisCommand = ThisConnection.CreateCommand();
                    thisCommand.CommandText = "select [Answer] from [Message] where Lower([message]) like '%"+ UserMessage + "%'";
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Read();
                    if (thisReader.HasRows)
                    {
                        Message = thisReader["Answer"].ToString();

                        row = table.NewRow();
                        row["Messange"] = Message;
                        row["Access"] = false;
                        table.Rows.Add(row);

                        UserMessage = "";
                    }
                    else
                    {
                        row = table.NewRow();
                        row["Messange"] = "К сожалению мой функционал ограничен, приношу свои извинения.";
                        row["Access"] = false;
                        table.Rows.Add(row);

                        UserMessage = "";
                    }
                    thisReader.Close();
                    ThisConnection.Close();

                    table2 = table;
                }
            }
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