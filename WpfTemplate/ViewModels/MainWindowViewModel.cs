using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Service;
using Prism.Services.Dialogs;

namespace WpfTemplate.ViewModels
{
    /// <summary>
    /// MainWindowのViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {

        //--------------------------------------------------------------------------------
        //コマンド
        //--------------------------------------------------------------------------------

        #region ConfirmCloseCommand
        private DelegateCommand<System.ComponentModel.CancelEventArgs> _ConfirmCloseCommand;
        public DelegateCommand<System.ComponentModel.CancelEventArgs> ConfirmCloseCommand
        {
            get
            {
                if(_ConfirmCloseCommand == null)
                {
                    _ConfirmCloseCommand = new DelegateCommand<System.ComponentModel.CancelEventArgs>((e) => 
                    {
                        var title = "終了";
                        var msg = "アプリケーションを終了しますか？";
                        MessageDialogService.Instance.ShowModal(title, msg, System.Windows.MessageBoxButton.YesNo, (res) =>
                        {
                            if(res.Result != ButtonResult.Yes)
                            {
                                e.Cancel = true;
                            }
                        });
                    });
                }
                return _ConfirmCloseCommand;
            }
        }
        #endregion
    }
}
