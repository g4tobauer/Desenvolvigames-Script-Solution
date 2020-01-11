using Assets.Scenes.Miscelanious;
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

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((LayerMask.NameToLayer(Constants.Layers.Pickupable) == col.gameObject.layer))
        {
            m_CharacterControllerScript.InventorySystem.StoreItem(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}
