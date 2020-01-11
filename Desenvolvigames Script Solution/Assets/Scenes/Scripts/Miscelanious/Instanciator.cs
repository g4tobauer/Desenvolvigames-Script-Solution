using Assets.Scenes.Character.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciator : MonoBehaviour
{
    public Chinelo Chinelo;
    public Bullet Bullet;

    public Chinelo InstantiateChinelo(Transform transform)
    {
        return Instantiate(Chinelo, transform.position, transform.rotation);
    }

    public Bullet InstantiateBullet(Transform transform)
    {
        return Instantiate(Bullet, transform.position, transform.rotation);
    }
}
