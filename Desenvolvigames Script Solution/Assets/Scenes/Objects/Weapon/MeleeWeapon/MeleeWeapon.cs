using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PickupableObject
{
    public MeleeWeaponObject MeleeWeaponObject;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        PickupableType = MeleeWeaponObject.PickupableType;
        SpriteRenderer.sprite = MeleeWeaponObject.Sprite;
        gameObject.layer = Converter.LayerMaskToInt(MeleeWeaponObject.LayerMask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
