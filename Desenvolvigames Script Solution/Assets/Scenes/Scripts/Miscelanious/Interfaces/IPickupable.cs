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
        bool CanBePicked { get; }
        Constants.Pickupable.PickupableType PickupableType { get; }

        T Pickup<T>() where T : IPickupable;
    }
}
