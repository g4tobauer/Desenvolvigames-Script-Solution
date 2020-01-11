using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]
public class WeaponSystem : MonoBehaviour
{
    public FireWeapon m_FireWeapon;
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        m_CharacterControllerScript.InputSystem.LookAtMousePosition(m_FireWeapon.transform);
        if (m_FireWeapon.m_ShootingMode == FireWeapon.ShootingMode.SEMIAUTOMATIC)
        {
            if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Mouse1))
            {
                m_FireWeapon.Shoot();
            }
        }
        if (m_FireWeapon.m_ShootingMode == FireWeapon.ShootingMode.AUTOMATIC)
        {
            if (m_CharacterControllerScript.InputSystem.GetKey(KeyCode.Mouse1))
            {
                m_FireWeapon.Shoot();
            }
        }
    }
}
