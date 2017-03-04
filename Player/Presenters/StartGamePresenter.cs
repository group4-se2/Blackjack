using System;
using Player.Interfaces;

namespace Player.Presenters
{
    class StartGamePresenter : IStartGamePresenter
    {
        private IStartGameModel model;
        private IStartGameView view;

        public StartGamePresenter(IStartGameModel model, IStartGameView view)
        {
            this.model = model;
            this.view = view;

            view.StartGamePresenter = this;
        }
        public void OnButton1Click()
        {
            IInGameView inGameView = new InGameView();
            inGameView.ShowDialog();
        }
        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
