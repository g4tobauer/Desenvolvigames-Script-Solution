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
        if (CurrentFireWeapon != null && CurrentFireWeapon.gameObject.activeInHierarchy)
        {
            if(Mathf.Abs(m_CharacterControllerScript.InputSystem.LookAtMousePosition(CurrentFireWeapon.transform)) > 90)
            {
                CurrentFireWeapon.transform.Rotate(180, 0, 0);
            }

            if (CurrentFireWeapon.FireWeaponObject.ShootingMode == Constants.Enumerations.FireWeapon.ShootingMode.SEMIAUTOMATIC)
            {
                if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
            }
            if (CurrentFireWeapon.FireWeaponObject.ShootingMode == Constants.Enumerations.FireWeapon.ShootingMode.AUTOMATIC)
            {
                if (m_CharacterControllerScript.InputSystem.GetKey(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
            }
            if (m_CharacterControllerScript.InputSystem.GetKey(KeyCode.R))
            {
                m_CharacterControllerScript.InventorySystem.ReloadCurrentWeapon();
            }
        }
    }
    public void SetCurrentFireWeapon(FireWeapon fireWeapon)
    {
        if (CurrentFireWeapon != null)
            CurrentFireWeapon.SpriteRenderer.enabled = false;
        CurrentFireWeapon = fireWeapon;
        if (CurrentFireWeapon != null)
            CurrentFireWeapon.SpriteRenderer.enabled = true;
    }   
    #endregion

    #region Properties
    public FireWeapon CurrentFireWeapon { get; private set; }
    #endregion
}
