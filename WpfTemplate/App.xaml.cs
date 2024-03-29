﻿using Prism.Ioc;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTemplate
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Property
        public IDialogService AppDialogService { get { return Container.Resolve<IDialogService>(); } }
        #endregion

        #region Method

        #region Event
        private void PrismApplication_Startup(object sender, StartupEventArgs e)
        {

        }

        private void PrismApplication_Exit(object sender, ExitEventArgs e)
        {

        }
        #endregion

        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 既存Window置き換え
            containerRegistry.RegisterDialogWindow<Views.DialogBase>();

            //ダイアログ登録
            containerRegistry.RegisterDialog<Views.Dialog.MessageDialog>();
        }
        #endregion
    }
}
