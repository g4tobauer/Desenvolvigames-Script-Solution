using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;

    #region Unity Methods
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
            if(Mathf.Abs(CharacterControllerScript.InputSystem.LookAtMousePosition(CurrentFireWeapon.transform)) > 90)
            {
                CurrentFireWeapon.transform.Rotate(180, 0, 0);
            }

            if (CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.R))
            {
                CharacterControllerScript.InventorySystem.ReloadCurrentWeapon();
            }
            if (CurrentFireWeapon.FireWeaponObject.ShootingMode == Constants.Enumerations.Weapon.FireWeapon.ShootingMode.SEMIAUTOMATIC)
            {
                if (CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
            }
            if (CurrentFireWeapon.FireWeaponObject.ShootingMode == Constants.Enumerations.Weapon.FireWeapon.ShootingMode.AUTOMATIC)
            {
                if (CharacterControllerScript.InputSystem.GetKey(KeyCode.Mouse1))
                {
                    CurrentFireWeapon.Shoot();
                }
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
