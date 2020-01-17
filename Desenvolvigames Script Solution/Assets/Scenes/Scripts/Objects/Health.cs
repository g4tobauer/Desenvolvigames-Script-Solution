using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PickupableObject
{
    [SerializeField]
    Constants.Enumerations.Pickupable.Amount.Size m_AmountSize = Constants.Enumerations.Pickupable.Amount.Size.Small;

    // Start is called before the first frame update
    public override void Start()
    {   
        base.Start();
        PickupableType = Constants.Enumerations.Pickupable.PickupableType.Health;
        switch (m_AmountSize)
        {
            case Constants.Enumerations.Pickupable.Amount.Size.Small:
                SpriteRenderer.sprite = Loader.Instancia.GetSprite(Constants.Resources.Sprites.Health.HealthSmall);
                break;
            case Constants.Enumerations.Pickupable.Amount.Size.Medium:
                SpriteRenderer.sprite = Loader.Instancia.GetSprite(Constants.Resources.Sprites.Health.HealthMedium);
                break;
            case Constants.Enumerations.Pickupable.Amount.Size.Large:
                SpriteRenderer.sprite = Loader.Instancia.GetSprite(Constants.Resources.Sprites.Health.HealthLarge);
                break;
            default:
                break;
        }
    }

    public int AmountHealth
    {
        get
        {
            switch(m_AmountSize)
            {
                case Constants.Enumerations.Pickupable.Amount.Size.Small:
                    return 30;
                case Constants.Enumerations.Pickupable.Amount.Size.Medium:
                    return 60;
                case Constants.Enumerations.Pickupable.Amount.Size.Large:
                    return 100;
            }
            return 0;
        }
    }
}
