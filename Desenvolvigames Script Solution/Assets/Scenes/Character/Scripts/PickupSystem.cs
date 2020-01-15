using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class PickupSystem : MonoBehaviour
{
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((LayerMask.NameToLayer(Constants.Layers.Pickupable) == col.gameObject.layer))
        {
            IPickupable pickupable;
            if (TryConvertGameObjectToPickupable(col.gameObject, out pickupable))
            {
                if(pickupable.CanBePicked)
                    Pickup(pickupable);
            }
        }
    }

    private bool TryConvertGameObjectToPickupable(GameObject game, out IPickupable pickupable)
    {
        pickupable = null;
        FireWeapon fireWeapon;
        if (game.TryGetComponent(out fireWeapon))
        {
            pickupable = fireWeapon;
            return true;
        }
        Health health;
        if (game.TryGetComponent(out health))
        {
            pickupable = health;
            return true;
        }
        Ammo ammo;
        if (game.TryGetComponent(out ammo))
        {
            pickupable = ammo;
            return true;
        }
        return false;
    }

    private void Pickup(IPickupable pickupable)
    {
        m_CharacterControllerScript.InventorySystem.StorePickupItem(pickupable);
    }
}
