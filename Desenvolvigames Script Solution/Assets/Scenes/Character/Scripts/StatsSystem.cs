using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class StatsSystem : MonoBehaviour
{
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    //Soma a quantidade de vida com a vida atual, caso exceda o valor de 100 retorna o excedente, caso contrario retorna 0
    public int AddHealth(int amountHealth)
    {
        if(Health < 100)
        {
            amountHealth += Health;
            if (amountHealth > 100)
            {
                Health = 100;
                return amountHealth - Health;
            }
            else
            {
                Health = amountHealth;
                return 0;
            }
        }
        return amountHealth;
    }

    public int Health { get; private set;}
}
