using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : PickupableObject
{
    public AmmoObject AmmoObject;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        SpriteRenderer.sprite = AmmoObject.Sprite;
        PickupableType = AmmoObject.PickupableType;
    }

    public int AmountAmmo
    {
        get
        {
            return AmmoObject.AmmoAmount;
        }
    }

    public Constants.Enumerations.Weapon.Projectile.ProjectileType ProjectileType { get { return AmmoObject.ProjectileAmmoType; } }
}
