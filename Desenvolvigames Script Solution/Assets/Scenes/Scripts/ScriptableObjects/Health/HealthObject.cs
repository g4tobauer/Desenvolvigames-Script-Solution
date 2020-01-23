using Assets.Scenes.Miscelanious;
using UnityEngine;

[CreateAssetMenu]
public class HealthObject : ScriptableObject
{
    public int HealthAmount;
    public Sprite Sprite;
    public Constants.Enumerations.Pickupable.PickupableType PickupableType = Constants.Enumerations.Pickupable.PickupableType.Health;
}
