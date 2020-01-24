using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{ 
    public Projectile IronProjectile;

    public void InstantiateObject(Transform transform, MonoBehaviour monoBehaviour)
    {
        Instantiate(monoBehaviour.gameObject,transform.position, transform.rotation);
    }
}