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

    public int AddHealth(int health)
    {
        if(m_HealthAmount < 100)
        {
            health += m_HealthAmount;
            if (health > 100)
            {
                m_HealthAmount = 100;
                return m_HealthAmount - health;
            }
            else
                m_HealthAmount = health;
        }
        return 0;
    }

    public int Health { get { return m_HealthAmount; } }
}
