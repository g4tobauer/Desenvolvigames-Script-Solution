using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PickupableObject
{
    [SerializeField]
    Constants.Pickupable.Amount.Size m_AmountSize;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        PickupableType = Constants.Pickupable.PickupableType.Health;
    }

    public int AmountHealth
    {
        get
        {
            switch(m_AmountSize)
            {
                case Constants.Pickupable.Amount.Size.Small:
                    return 30;
                case Constants.Pickupable.Amount.Size.Medium:
                    return 60;
                case Constants.Pickupable.Amount.Size.Large:
                    return 100;
            }
            return 0;
        }
    }
}
