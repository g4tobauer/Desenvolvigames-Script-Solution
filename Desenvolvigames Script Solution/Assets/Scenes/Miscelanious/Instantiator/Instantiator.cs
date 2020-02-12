using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{ 
    public Projectile IronProjectile;

    public void InstantiateObject(Transform transform, GameObject gameObject)
    {
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}