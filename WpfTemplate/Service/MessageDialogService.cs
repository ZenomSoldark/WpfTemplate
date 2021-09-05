using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTemplate.ViewModels.Dialog;

namespace WpfTemplate.Service
{
    public class MessageDialogService
    {
        /// <summary> シングルトンインスタンス </summary>
        public static MessageDialogService Instance { get; } = new MessageDialogService();

        /// <summary>
        /// コンストラクタ
        /// (シングルトンインスタンスなのでプライベート)
        /// </summary>
        private MessageDialogService()
        {
            _DialogService = ((App)Application.Current).AppDialogService;
        }

        #region Field
        private IDialogService _DialogService;
        #endregion

        #region Property
        public string YesText { get; set; } = "はい";
        public string NoText { get; set; } = "いいえ";
        public string OkText { get; set; } = "OK";
        public string CancelText { get; set; } = "キャンセル";
        #endregion

        #region Method
        /// <summary>
        /// 簡易的なモーダルダイアログを表示
        /// </summary>
        /// <param name="dialogService">The dialog service.</param>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        public void ShowModal(string title, string message, Action<IDialogResult> callback)
        {
            var name = nameof(Views.Dialog.MessageDialog);
            var parameters = new DialogParameters()
                {
                    { nameof(MessageDialogViewModel.Title), title },
                    { nameof(MessageDialogViewModel.Message), message },
                    { nameof(MessageDialogViewModel.DialogButton), MessageBoxButton.OK },
                    { nameof(MessageDialogViewModel.OkText), OkText },
                };
            _DialogService.ShowDialog(name, parameters, callback);
        }

        /// <summary>
        /// ボタン要素を設定したモーダルダイアログを表示
        /// </summary>
        /// <param name="dialogService">The dialog service.</param>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="button">The button.</param>
        /// <param name="callback">The callback.</param>
        public void ShowModal(string title, string message, MessageBoxButton button, Action<IDialogResult> callback)
        {
            var name = nameof(Views.Dialog.MessageDialog);
            var parameters = new DialogParameters()
                {
                    { nameof(MessageDialogViewModel.Title), title },
                    { nameof(MessageDialogViewModel.Message), message },
                    { nameof(MessageDialogViewModel.DialogButton), button },
                    { nameof(MessageDialogViewModel.YesText), YesText },
                    { nameof(MessageDialogViewModel.NoText), NoText },
                    { nameof(MessageDialogViewModel.OkText), OkText },
                    { nameof(MessageDialogViewModel.CancelText), CancelText },
                };
            _DialogService.ShowDialog(name, parameters, callback);
        }

        /// <summary>
        /// 簡易的なモードレスダイアログを表示
        /// </summary>
        /// <param name="dialogService">The dialog service.</param>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        public void ShowModeless(string title, string message, Action<IDialogResult> callback)
        {
            var name = nameof(Views.Dialog.MessageDialog);
            var parameters = new DialogParameters()
                {
                    { nameof(MessageDialogViewModel.Title), title },
                    { nameof(MessageDialogViewModel.Message), message },
                    { nameof(MessageDialogViewModel.DialogButton), MessageBoxButton.OK },
                    { nameof(MessageDialogViewModel.OkText), OkText },
                };
            _DialogService.Show(name, parameters, callback);
        }

        /// <summary>
        /// ボタン要素を設定したモードレスダイアログを表示
        /// </summary>
        /// <param name="dialogService">The dialog service.</param>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="button">The button.</param>
        /// <param name="callback">The callback.</param>
        public void ShowModeless(string title, string message, MessageBoxButton button, Action<IDialogResult> callback)
        {
            var name = nameof(Views.Dialog.MessageDialog);
            var parameters = new DialogParameters()
                {
                    { nameof(MessageDialogViewModel.Title), title },
                    { nameof(MessageDialogViewModel.Message), message },
                    { nameof(MessageDialogViewModel.DialogButton), button },
                    { nameof(MessageDialogViewModel.YesText), YesText },
                    { nameof(MessageDialogViewModel.NoText), NoText },
                    { nameof(MessageDialogViewModel.OkText), OkText },
                    { nameof(MessageDialogViewModel.CancelText), CancelText },
                };
            _DialogService.Show(name, parameters, callback);
        }
        #endregion
    }
}
