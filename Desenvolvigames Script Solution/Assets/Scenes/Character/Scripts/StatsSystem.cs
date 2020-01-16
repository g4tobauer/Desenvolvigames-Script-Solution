using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class StatsSystem : MonoBehaviour
{
    private int m_HealthAmount;
    private CharacterControllerScript m_CharacterControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    public int AddHealth(int amountHealth)
    {
        if(m_HealthAmount < 100)
        {
            amountHealth += m_HealthAmount;
            if (amountHealth > 100)
            {
                m_HealthAmount = 100;
                return amountHealth - m_HealthAmount;
            }
            else
            {
                m_HealthAmount = amountHealth;
                return 0;
            }
        }
        return amountHealth;
    }

    public int Health { get { return m_HealthAmount; } }
}
