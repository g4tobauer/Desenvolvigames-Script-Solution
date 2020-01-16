using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class InventorySystem : MonoBehaviour
{
    public Dictionary<Constants.Projectile.ProjectileType, int> ProjectilesBag = new Dictionary<Constants.Projectile.ProjectileType, int>();
    private List<FireWeapon> FireWeaponBag = new List<FireWeapon>();
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
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

    public void ReloadWeapon(FireWeapon fireWeapon)
    {
        fireWeapon.ReloadClip(ProjectilesBag);
    }
    public void StorePickupItem(IPickupable pickupable)
    {
        switch(pickupable.PickupableType)
        {
            case Constants.Pickupable.PickupableType.FireWeapon:
                StoreFireWeapon(pickupable.Pickup<FireWeapon>());
                break;
            case Constants.Pickupable.PickupableType.Health:
                StoreHealth(pickupable.Pickup<Health>());
                break;
            case Constants.Pickupable.PickupableType.Ammo:
                StoreAmmo(pickupable.Pickup<Ammo>());
                break;
        }
    }
    private void StoreFireWeapon(FireWeapon fireWeapon)
    {
        if (!FireWeaponBag.Contains(fireWeapon))
        {
            fireWeapon.transform.SetParent(m_CharacterControllerScript.transform);
            fireWeapon.transform.localRotation = Quaternion.identity;
            fireWeapon.transform.localPosition = Vector3.zero;
            fireWeapon.gameObject.SetActive(false);
            FireWeaponBag.Add(fireWeapon);
        }
    }
    private void StoreHealth(Health health)
    {
        var overHealth = m_CharacterControllerScript.StatsSystem.AddHealth(health.AmountHealth);

        overHealth += StoredHealth;
        if (overHealth < 50)
            StoredHealth = overHealth;
        else
            StoredHealth = 50;

        Destroy(health.gameObject);
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
        }else
        {
            ammo.ResetPicked();
        }
    }

    #region Properties
    public int StoredHealth { get; private set; }
    public int StoredAmmo { get { return ProjectilesBag[m_CharacterControllerScript.WeaponSystem.CurrentFireWeapon.CurrentProjectileType]; } }
    #endregion
}
