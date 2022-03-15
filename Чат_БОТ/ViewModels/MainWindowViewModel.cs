using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Чат_БОТ.ViewModels.Base;

namespace Чат_БОТ.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Имя Бота : NameBot

        private string _NameBot = "Чат бот";

        /// <summary>NameBot</summary>
        public string NameBot
        {
            get => _NameBot;
            set => Set(ref _NameBot, value);
        }

        #endregion
    }
}
