using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudSystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;


    public string HudHealth
    { get
        {
            return CharacterControllerScript.StatsSystem.Health.ToString();
        }
    }

    public string HudStoredAmmo
    {
        get
        {
            return CharacterControllerScript.InventorySystem.StoredAmmo.ToString();
        }
    }

    public string HudCurrentWeaponAmmo
    {
        get
        {
            if (CharacterControllerScript.WeaponSystem.CurrentFireWeapon == null)
                return "0";
            return CharacterControllerScript.WeaponSystem.CurrentFireWeapon.CurrentProjectileAmmo.ToString();
        }
    }
}
