using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTemplate.ViewModels.Dialog
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        //--------------------------------------------------------------------------------
        //フィールド
        //--------------------------------------------------------------------------------
        /// <summary> Instructs the IDialogWindow to close the dialog.  </summary>
        public event Action<IDialogResult> RequestClose;


        //--------------------------------------------------------------------------------
        //プロパティ
        //--------------------------------------------------------------------------------

        #region Title変更通知プロパティ
        private string _Title;
        /// <summary>
        /// The title of the dialog that will show in the Window title bar.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        #endregion

        #region Message変更通知プロパティ
        private string _Message;
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }
        #endregion

        #region YesText変更通知プロパティ
        private string _YesText;
        /// <summary>
        /// Gets or sets the yes text.
        /// </summary>
        /// <value>
        /// The yes text.
        /// </value>
        public string YesText
        {
            get { return _YesText; }
            set { SetProperty(ref _YesText, value); }
        }
        #endregion

        #region NoText変更通知プロパティ
        private string _NoText;
        /// <summary>
        /// Gets or sets the no text.
        /// </summary>
        /// <value>
        /// The no text.
        /// </value>
        public string NoText
        {
            get { return _NoText; }
            set { SetProperty(ref _NoText, value); }
        }
        #endregion

        #region OkText変更通知プロパティ
        private string _OkText = "OK";
        /// <summary>
        /// Gets or sets the ok text.
        /// </summary>
        /// <value>
        /// The ok text.
        /// </value>
        public string OkText
        {
            get { return _OkText; }
            set { SetProperty(ref _OkText, value); }
        }
        #endregion

        #region CancelText変更通知プロパティ
        private string _CancelText;
        /// <summary>
        /// Gets or sets the cancel text.
        /// </summary>
        /// <value>
        /// The cancel text.
        /// </value>
        public string CancelText
        {
            get { return _CancelText; }
            set { SetProperty(ref _CancelText, value); }
        }
        #endregion

        #region DisplayYesButton
        private bool _DisplayYesButton;
        /// <summary>
        /// Gets or sets a value indicating whether [display yes button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display yes button]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayYesButton
        {
            get { return _DisplayYesButton; }
            set { SetProperty(ref _DisplayYesButton, value); }
        }
        #endregion

        #region DisplayNoButton
        private bool _DisplayNoButton;
        /// <summary>
        /// Gets or sets a value indicating whether [display no button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display no button]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayNoButton
        {
            get { return _DisplayNoButton; }
            set { SetProperty(ref _DisplayNoButton, value); }
        }
        #endregion

        #region DisplayOkButton
        private bool _DisplayOkButton = true;
        public bool DisplayOkButton
        {
            get { return _DisplayOkButton; }
            set { SetProperty(ref _DisplayOkButton, value); }
        }
        #endregion

        #region DisplayCancelButton
        private bool _DisplayCancelButton;
        /// <summary>
        /// Gets or sets a value indicating whether [display cancel button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [display cancel button]; otherwise, <c>false</c>.
        /// </value>
        public bool DisplayCancelButton
        {
            get { return _DisplayCancelButton; }
            set { SetProperty(ref _DisplayCancelButton, value); }
        }
        #endregion

        #region DialogButton変更通知プロパティ
        private MessageBoxButton _DialogButton = MessageBoxButton.OK;
        public MessageBoxButton DialogButton
        {
            get { return _DialogButton; }
            set
            {
                SetProperty(ref _DialogButton, value, () =>
                {
                    switch (value)
                    {
                        case MessageBoxButton.OK:
                            DisplayYesButton = false;
                            DisplayNoButton = false;
                            DisplayOkButton = true;
                            DisplayCancelButton = false;
                            break;

                        case MessageBoxButton.OKCancel:
                            DisplayYesButton = false;
                            DisplayNoButton = false;
                            DisplayOkButton = true;
                            DisplayCancelButton = true;
                            break;

                        case MessageBoxButton.YesNo:
                            DisplayYesButton = true;
                            DisplayNoButton = true;
                            DisplayOkButton = false;
                            DisplayCancelButton = false;
                            break;

                        case MessageBoxButton.YesNoCancel:
                            DisplayYesButton = true;
                            DisplayNoButton = true;
                            DisplayOkButton = false;
                            DisplayCancelButton = true;
                            break;

                        default:
                            break;
                    }
                });
            }
        }
        #endregion


        //--------------------------------------------------------------------------------
        //コマンド
        //--------------------------------------------------------------------------------

        #region YesCommand
        private DelegateCommand _YesCommand;
        public DelegateCommand YesCommand
        {
            get
            {
                if (_YesCommand == null)
                {
                    _YesCommand = new DelegateCommand(YesAction);
                }
                return _YesCommand;
            }
        }

        private void YesAction()
        {
            var parameters = new DialogParameters()
            {
                { nameof(MessageDialogViewModel), null },
            };
            RequestClose.Invoke(new DialogResult(ButtonResult.Yes, parameters));
        }
        #endregion

        #region NoCommand
        private DelegateCommand _NoCommand;
        public DelegateCommand NoCommand
        {
            get
            {
                if (_NoCommand == null)
                {
                    _NoCommand = new DelegateCommand(NoAction);
                }
                return _NoCommand;
            }
        }

        private void NoAction()
        {
            var parameters = new DialogParameters()
            {
                { nameof(MessageDialogViewModel), null },
            };
            RequestClose.Invoke(new DialogResult(ButtonResult.No, parameters));
        }
        #endregion

        #region OkCommand
        private DelegateCommand _OkCommand;
        public DelegateCommand OkCommand
        {
            get
            {
                if (_OkCommand == null)
                {
                    _OkCommand = new DelegateCommand(OkAction);
                }
                return _OkCommand;
            }
        }

        private void OkAction()
        {
            var parameters = new DialogParameters()
            {
                { nameof(MessageDialogViewModel), null },
            };
            RequestClose.Invoke(new DialogResult(ButtonResult.OK, parameters));
        }
        #endregion

        #region CancelCommand
        private DelegateCommand _CancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new DelegateCommand(CancelAction);
                }
                return _CancelCommand;
            }
        }

        private void CancelAction()
        {
            var parameters = new DialogParameters()
            {
                { nameof(MessageDialogViewModel), null },
            };
            RequestClose.Invoke(new DialogResult(ButtonResult.Cancel, parameters));
        }
        #endregion

        //--------------------------------------------------------------------------------
        //メソッド
        //--------------------------------------------------------------------------------

        /// <summary>
        /// Determines if the dialog can be closed.
        /// </summary>
        /// <returns>
        /// True: close the dialog; False: the dialog will not close
        /// </returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// Called when the dialog is closed.
        /// </summary>
        public void OnDialogClosed()
        {

        }

        /// <summary>
        /// Called when the dialog is opened.
        /// </summary>
        /// <param name="parameters">The parameters passed to the dialog</param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>(nameof(Title));
            Message = parameters.GetValue<string>(nameof(Message));
            DialogButton = parameters.GetValue<MessageBoxButton>(nameof(DialogButton));
            YesText = parameters.GetValue<string>(nameof(YesText));
            NoText = parameters.GetValue<string>(nameof(NoText));
            OkText = parameters.GetValue<string>(nameof(OkText));
            CancelText = parameters.GetValue<string>(nameof(CancelText));
        }
    }
}
