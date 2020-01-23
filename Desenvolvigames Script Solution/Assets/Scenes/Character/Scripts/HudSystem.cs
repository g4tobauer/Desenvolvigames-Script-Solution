using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class HudSystem : MonoBehaviour
{
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    public string HudHealth
    { get
        {
            return m_CharacterControllerScript.StatsSystem.Health.ToString();
        }
    }

    public string HudStoredAmmo
    {
        get
        {
            return m_CharacterControllerScript.InventorySystem.StoredAmmo.ToString();
        }
    }
}
