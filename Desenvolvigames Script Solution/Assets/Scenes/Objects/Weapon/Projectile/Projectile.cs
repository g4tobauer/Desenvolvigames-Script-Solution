using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private Constants.Enumerations.Weapon.Projectile.ProjectileType CurrentProjectileType;

    public SpriteRenderer SpriteRenderer;
    public ProjectileObject ProjectileObject;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = transform.right * ProjectileObject.Velocity;
        CurrentProjectileType = ProjectileObject.ProjectileType;
        SpriteRenderer.sprite = ProjectileObject.Sprite;
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((LayerMask.NameToLayer(Constants.Layers.Targetable) == col.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
