using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class InventorySystem : MonoBehaviour
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

    public void StoreItem(GameObject item)
    {

    }
}
