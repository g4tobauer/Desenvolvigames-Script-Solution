using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class InventorySystem : MonoBehaviour
{
    private List<FireWeapon> FireWeaponList = new List<FireWeapon>();
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
            if(FireWeaponList.Count > 0)
                m_CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(FireWeaponList[0]);
        }
        if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Alpha2))
            m_CharacterControllerScript.WeaponSystem.SetCurrentFireWeapon(null);
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
        }
    }

    private void StoreFireWeapon(FireWeapon fireWeapon)
    {
        if (!FireWeaponList.Contains(fireWeapon))
        {
            fireWeapon.transform.SetParent(m_CharacterControllerScript.transform);
            fireWeapon.transform.localRotation = Quaternion.identity;
            fireWeapon.transform.localPosition = Vector3.zero;
            fireWeapon.gameObject.SetActive(false);
            FireWeaponList.Add(fireWeapon);
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

    #region Properties
    public int StoredHealth { get; private set; }
    #endregion
}
