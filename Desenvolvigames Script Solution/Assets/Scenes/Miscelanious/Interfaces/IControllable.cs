using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Character.Interfaces
{
    public interface IControllable
    {
        bool WithControl { get; }
        bool IsFinishedControl { get; }
        bool PassControl();
        void TakeControl(IControllable controllable);
    }
}
