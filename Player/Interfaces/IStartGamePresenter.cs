using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Interfaces
{
    public interface IStartGamePresenter
    {
        void OnButton1Click();
        void UpdateView();
        void goButtonClick(String name);
    }
}
