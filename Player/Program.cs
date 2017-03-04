using Player.Interfaces;
using Player.Models;
using Player.Presenters;
using System;
using System.Windows.Forms;

namespace Player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Model
            StartGameModel model = new StartGameModel();

            // View
            StartGameView view = new StartGameView();

            // Presenter
            IStartGamePresenter presenter = new StartGamePresenter(model, view);

            Application.Run(view);
            //Application.Run(new Form1());
        }
    }
}
