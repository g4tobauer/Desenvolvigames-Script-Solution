using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireWeaponObject : ScriptableObject
{
    public float AutomaticTimeShoot = .08F;
    public float SemiAutomaticTimeShoot = .1F;
    public Sprite Sprite;
    public Constants.Enumerations.FireWeapon.ShootingMode ShootingMode;
    public Constants.Enumerations.Pickupable.PickupableType PickupableType = Constants.Enumerations.Pickupable.PickupableType.FireWeapon;
    public Constants.Enumerations.Projectile.ProjectileType ProjectileTypeDefault = Constants.Enumerations.Projectile.ProjectileType.Iron;
}
