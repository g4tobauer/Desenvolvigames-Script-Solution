using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventorySystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        ProjectilesBag[Constants.Enumerations.Weapon.Projectile.ProjectileType.Iron] = 0;
    }
    private void Update()
    {
        if (CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Alpha1))
        {
            if(FireWeaponBag.Count > 0)
                CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(FireWeaponBag[0]);
        }
        if (CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Alpha2))
            CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(null);
    }
    #endregion

    #region Methods 
    private void AttachPickupableObject(PickupableObject pickupableObject)
    {
        pickupableObject.transform.SetParent(CharacterControllerScript.transform);
        pickupableObject.transform.localRotation = Quaternion.identity;
        pickupableObject.transform.localPosition = Vector3.zero;
        pickupableObject.SpriteRenderer.enabled = false;
    }
    private void StoreMeleeWeapon(MeleeWeapon meleeWeapon)
    {
        if (!MeleeWeaponBag.Contains(meleeWeapon))
        {
            AttachPickupableObject(meleeWeapon);
            MeleeWeaponBag.Add(meleeWeapon);
        }
    }
    private void StoreFireWeapon(FireWeapon fireWeapon)
    {
        if (!FireWeaponBag.Contains(fireWeapon))
        {
            AttachPickupableObject(fireWeapon);
            FireWeaponBag.Add(fireWeapon);
        }
    }
    private void StoreAmmo(Ammo ammo)
    {
        if (!ProjectilesBag.ContainsKey(ammo.ProjectileType))
            ProjectilesBag[ammo.ProjectileType] = 0;

        var amount = ProjectilesBag[ammo.ProjectileType] + ammo.AmountAmmo;

        if (amount <= 30)
        {
            ProjectilesBag[ammo.ProjectileType] = amount;
            Destroy(ammo.gameObject);
        }
        else
        {
            ammo.ResetPicked();
        }
    }
    private void StoreHealth(Health health)
    {
        var overHealth = CharacterControllerScript.StatsSystem.AddHealth(health.HealthAmount);

        overHealth += StoredHealth;
        if (overHealth < 50)
            StoredHealth = overHealth;
        else
            StoredHealth = 50;

        Destroy(health.gameObject);
    }

    public void ReloadCurrentWeapon()
    {
        CharacterControllerScript.WeaponSystem.CurrentFireWeapon.ReloadClip(ProjectilesBag);
    }
    public void StorePickupItem(IPickupable pickupable)
    {
        switch (pickupable.PickupableType)
        {
            case Constants.Enumerations.Pickupable.PickupableType.FireWeapon:
                StoreFireWeapon(pickupable.Pickup<FireWeapon>());
                break;
            case Constants.Enumerations.Pickupable.PickupableType.MeleeWeapon:
                StoreMeleeWeapon(pickupable.Pickup<MeleeWeapon>());
                break;
            case Constants.Enumerations.Pickupable.PickupableType.Health:
                StoreHealth(pickupable.Pickup<Health>());
                break;
            case Constants.Enumerations.Pickupable.PickupableType.Ammo:
                StoreAmmo(pickupable.Pickup<Ammo>());
                break;
        }
    }
    #endregion

    #region Properties
    private List<FireWeapon> FireWeaponBag { get; } = new List<FireWeapon>();
    private List<MeleeWeapon> MeleeWeaponBag { get; } = new List<MeleeWeapon>();
    private Dictionary<Constants.Enumerations.Weapon.Projectile.ProjectileType, int> ProjectilesBag { get; } = new Dictionary<Constants.Enumerations.Weapon.Projectile.ProjectileType, int>();

    public int StoredHealth { get; private set; }
    public int StoredAmmo
    {
        get
        {
            if (CharacterControllerScript.WeaponSystem.CurrentFireWeapon == null)
                return 0;
            return ProjectilesBag[CharacterControllerScript.WeaponSystem.CurrentFireWeapon.CurrentProjectileType];
        }
    }
    #endregion
}
