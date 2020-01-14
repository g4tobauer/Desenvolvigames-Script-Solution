using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PickupableObject
{
    public Constants.Pickupable.Amount.Size m_AmountSize;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        PickupableType = Constants.Pickupable.PickupableType.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
