using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class InventorySystem : MonoBehaviour
{
    private CharacterControllerScript m_CharacterControllerScript;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        ProjectilesBag[Constants.Enumerations.Projectile.ProjectileType.Iron] = 0;
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }
    private void Update()
    {
        if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Alpha1))
        {
            if(FireWeaponBag.Count > 0)
                m_CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(FireWeaponBag[0]);
        }
        if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Alpha2))
            m_CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(null);
    }
    #endregion

    #region Methods
    private void StoreFireWeapon(FireWeapon fireWeapon)
    {
        if (!FireWeaponBag.Contains(fireWeapon))
        {
            fireWeapon.transform.SetParent(m_CharacterControllerScript.transform);
            fireWeapon.transform.localRotation = Quaternion.identity;
            fireWeapon.transform.localPosition = Vector3.zero;
            fireWeapon.SpriteRenderer.enabled = false;
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
        var overHealth = m_CharacterControllerScript.StatsSystem.AddHealth(health.HealthAmount);

        overHealth += StoredHealth;
        if (overHealth < 50)
            StoredHealth = overHealth;
        else
            StoredHealth = 50;

        Destroy(health.gameObject);
    }

    public void ReloadCurrentWeapon()
    {
        m_CharacterControllerScript.WeaponSystem.CurrentFireWeapon.ReloadClip(ProjectilesBag);
    }
    public void StorePickupItem(IPickupable pickupable)
    {
        switch (pickupable.PickupableType)
        {
            case Constants.Enumerations.Pickupable.PickupableType.FireWeapon:
                StoreFireWeapon(pickupable.Pickup<FireWeapon>());
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
    private Dictionary<Constants.Enumerations.Projectile.ProjectileType, int> ProjectilesBag { get; } = new Dictionary<Constants.Enumerations.Projectile.ProjectileType, int>();

    public int StoredHealth { get; private set; }
    public int StoredAmmo
    {
        get
        {
            if (m_CharacterControllerScript.WeaponSystem.CurrentFireWeapon == null)
                return 0;
            return ProjectilesBag[m_CharacterControllerScript.WeaponSystem.CurrentFireWeapon.CurrentProjectileType];
        }
    }
    #endregion
}
