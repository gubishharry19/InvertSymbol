using System;
using System.Windows.Forms;

namespace InvertSymbolUaEng
{
    class Present
    {
        MainWindow main;
        Model model;
        string text;
        KeyboardHook hook = new KeyboardHook();
        public Present(MainWindow main)
        {
            this.main = main;
            model = new Model();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Main_ActionConvert);
            hook.RegisterHotKey(ModifierKeys.Control, Keys.M);
            this.main.ActionConvert += Main_ActionConvert;
        }
        #region Функція делегату. Реагує при нажатті на кнопку або при нажатті Cntr+M
        private void Main_ActionConvert(object sender, EventArgs e)
        {
            string inv_text;
            if (Clipboard.ContainsText())
            {
                try
                {
                    text = Clipboard.GetText();
                    inv_text = model.Convert(text, Model.IsEng(text));
                    Clipboard.SetText(inv_text, TextDataFormat.UnicodeText);

                    main.notifyIcon.Text = "Success";
                    main.notifyIcon.BalloonTipTitle = "Success";
                    main.notifyIcon.BalloonTipText = "Мало би запрацювати";
                }
                catch (Exception ex)
                {
                    main.notifyIcon.Text = "Error";
                    main.notifyIcon.BalloonTipTitle = "Error";
                    main.notifyIcon.BalloonTipText = "Текст містить символи на двох різних мовних розкладках.\n" +
                        "В цій версії програми можна конвертувати текст на Eng- та Ua-розкладках\n" +
                        "Error:" + ex.Message;
                }
                finally
                {
                    main.notifyIcon.ShowBalloonTip(1000);
                }
            }
            else
            {
                MessageBox.Show("Не запрацювало. В буфері збережено не текст.");
                return;
            }

        }
    }
    #endregion
}
