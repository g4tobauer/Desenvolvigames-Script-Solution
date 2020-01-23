using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PickupableObject
{
    public HealthObject HealthObject;

    // Start is called before the first frame update
    public override void Start()
    {   
        base.Start();
        SpriteRenderer.sprite = HealthObject.Sprite;
        PickupableType = HealthObject.PickupableType;
    }

    public int HealthAmount
    {
        get
        {
            return HealthObject.HealthAmount;
        }
    }
}
