using Assets.Scenes.Miscelanious;
using UnityEngine;

[CreateAssetMenu]
public class AmmoObject : ScriptableObject
{
    public int AmmoAmount;
    public Sprite Sprite;
    public Constants.Enumerations.Weapon.Projectile.ProjectileType ProjectileAmmoType;
    public Constants.Enumerations.Pickupable.PickupableType PickupableType = Constants.Enumerations.Pickupable.PickupableType.Ammo;
}
