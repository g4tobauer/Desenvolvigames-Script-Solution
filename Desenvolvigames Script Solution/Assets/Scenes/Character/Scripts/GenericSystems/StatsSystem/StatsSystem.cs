using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;

    //Soma a quantidade de vida com a vida atual, caso exceda o valor de 100 retorna o excedente, caso contrario retorna 0
    public int AddHealth(int amountHealth)
    {
        if (Health < Constants.StatsSystem.Health.MaxHeath)
        {
            amountHealth += Health;
            if (amountHealth > Constants.StatsSystem.Health.MaxHeath)
            {
                Health = Constants.StatsSystem.Health.MaxHeath;
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
