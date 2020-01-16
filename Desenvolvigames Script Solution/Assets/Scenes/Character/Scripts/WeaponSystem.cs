using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]
public class WeaponSystem : MonoBehaviour
{
    private CharacterControllerScript m_CharacterControllerScript;

    #region Unity Methods
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
    #endregion
    
    #region Methods
    private void Inputs()
    {
        if (CurrentFireWeapon != null)
        {
            if(Mathf.Abs(m_CharacterControllerScript.InputSystem.LookAtMousePosition(CurrentFireWeapon.transform)) > 90)
            {
                CurrentFireWeapon.transform.Rotate(180, 0, 0);
            }

            if (CurrentFireWeapon.m_ShootingMode == FireWeapon.ShootingMode.SEMIAUTOMATIC)
            {
                if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
            }
            if (CurrentFireWeapon.m_ShootingMode == FireWeapon.ShootingMode.AUTOMATIC)
            {
                if (m_CharacterControllerScript.InputSystem.GetKey(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
            }
            if (m_CharacterControllerScript.InputSystem.GetKey(KeyCode.R))
            {
                m_CharacterControllerScript.InventorySystem.ReloadWeapon(CurrentFireWeapon);
            }
        }
    }
    public void SetCurrentFireWeapon(FireWeapon fireWeapon)
    {
        if (CurrentFireWeapon != null)
            CurrentFireWeapon.gameObject.SetActive(false);
        CurrentFireWeapon = fireWeapon;
        if (CurrentFireWeapon != null)
            CurrentFireWeapon.gameObject.SetActive(true);
    }   
    #endregion

    #region Properties
    public FireWeapon CurrentFireWeapon { get; private set; }
    #endregion
}
