using Assets.Scenes.Miscelanious;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scenes.Scripts.Miscelanious.Interfaces
{
    public interface IPickupable
    {
        Constants.Enumerations.Pickupable.PickupableType PickupableType { get; }
        void ResetPicked();
        T Pickup<T>() where T : IPickupable;
        bool CanBePicked { get; }
    }
}
