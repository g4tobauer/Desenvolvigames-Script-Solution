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

    //Pega gameobjects do tipo IPickupable e com layer Pickupable
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

    //Tenta converter um gameobject para um componete que implementa IPickupable
    private bool TryConvertGameObjectToPickupable(GameObject game, out IPickupable pickupable)
    {
        pickupable = null;
        if (game.TryGetComponent(out FireWeapon fireWeapon))
        {
            pickupable = fireWeapon;
            return true;
        }
        if (game.TryGetComponent(out Health health))
        {
            pickupable = health;
            return true;
        }
        if (game.TryGetComponent(out Ammo ammo))
        {
            pickupable = ammo;
            return true;
        }
        return false;
    }

    //Pega o objeto e envia para o Inventario para ser manipulado.
    private void Pickup(IPickupable pickupable)
    {
        m_CharacterControllerScript.InventorySystem.StorePickupItem(pickupable);
    }
}
