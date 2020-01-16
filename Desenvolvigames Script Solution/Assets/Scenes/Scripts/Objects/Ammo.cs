using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : PickupableObject
{
    [SerializeField]
    Constants.Pickupable.Amount.Size m_AmountSize = Constants.Pickupable.Amount.Size.Small;

    [SerializeField]
    Constants.Projectile.ProjectileType m_ProjectileType = Constants.Projectile.ProjectileType.Iron;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        PickupableType = Constants.Pickupable.PickupableType.Ammo;
    }

    public int AmountAmmo
    {
        get
        {
            switch (m_AmountSize)
            {
                case Constants.Pickupable.Amount.Size.Small:
                    return 5;
                case Constants.Pickupable.Amount.Size.Medium:
                    return 10;
                case Constants.Pickupable.Amount.Size.Large:
                    return 15;
            }
            return 0;
        }
    }

    public Constants.Projectile.ProjectileType ProjectileType { get { return m_ProjectileType; } }
}
