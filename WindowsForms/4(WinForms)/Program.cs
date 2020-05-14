using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_WinForms_
{
    static class Program
    {
        static DialogResult ShowMessageBoxes()
        {
            var message = "Окно, отображающее текстовое сообщение";
            MessageBox.Show(message);

            message = "Окно с дыумя кнопками, Ok and Cancel";
            var caption = "Окно с двумя кнопками";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

            result = MessageBox.Show(
                "Повторить?",
                result.ToString(),
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Hand
                );

            return result;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            DialogResult result;
            do
            {
                result = ShowMessageBoxes();
            } while (result==DialogResult.Yes);
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
