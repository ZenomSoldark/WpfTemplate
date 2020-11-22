using Prism.Ioc;
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
        //--------------------------------------------------------------------------------
        //プロパティ
        //--------------------------------------------------------------------------------
        public IDialogService AppDialogService { get { return Container.Resolve<IDialogService>(); } }

        //--------------------------------------------------------------------------------
        //メソッド
        //--------------------------------------------------------------------------------
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
    }
}
