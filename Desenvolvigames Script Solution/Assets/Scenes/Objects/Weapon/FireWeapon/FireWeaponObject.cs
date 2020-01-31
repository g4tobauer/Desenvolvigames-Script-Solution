using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireWeaponObject : ScriptableObject
{
    public float AutomaticTimeShoot = .08F;
    public float SemiAutomaticTimeShoot = .1F;
    public int WeaponClipSize = 7;
    public Sprite Sprite;
    public LayerMask LayerMask;
    public Constants.Enumerations.Weapon.FireWeapon.ShootingMode ShootingMode;
    public Constants.Enumerations.Pickupable.PickupableType PickupableType = Constants.Enumerations.Pickupable.PickupableType.FireWeapon;
    public Constants.Enumerations.Weapon.Projectile.ProjectileType ProjectileTypeDefault = Constants.Enumerations.Weapon.Projectile.ProjectileType.Iron;
}
