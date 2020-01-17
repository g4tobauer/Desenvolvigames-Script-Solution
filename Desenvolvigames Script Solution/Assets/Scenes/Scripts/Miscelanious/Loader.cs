using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Loader
{
    static Loader _instancia;
    private readonly static Dictionary<string, Sprite> LoadedSprite = new Dictionary<string, Sprite>();
    private readonly static Dictionary<string, GameObject> LoadedPrefab = new Dictionary<string, GameObject>();
    public static Loader Instancia
    {
        get { return _instancia ?? (_instancia = new Loader()); }
    }
    private Loader()
    {
        LoadSprites();
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        LoadedPrefab[Constants.Resources.Prefabs.Projectiles.IronProjectile] = Resources.Load<GameObject>(Constants.Resources.Prefabs.Projectiles.ProjectilesPath + Constants.Resources.Prefabs.Projectiles.IronProjectile);
    }
    public GameObject GetPrefab(string prefabName)
    {
        return LoadedPrefab[prefabName];
    }

    private void LoadSprites()
    {
        LoadedSprite[Constants.Resources.Sprites.Health.HealthSmall] = Resources.Load<Sprite>(Constants.Resources.Sprites.Health.HealthPath + Constants.Resources.Sprites.Health.HealthSmall);
        LoadedSprite[Constants.Resources.Sprites.Health.HealthMedium] = Resources.Load<Sprite>(Constants.Resources.Sprites.Health.HealthPath + Constants.Resources.Sprites.Health.HealthMedium);
        LoadedSprite[Constants.Resources.Sprites.Health.HealthLarge] = Resources.Load<Sprite>(Constants.Resources.Sprites.Health.HealthPath + Constants.Resources.Sprites.Health.HealthLarge);

        LoadedSprite[Constants.Resources.Sprites.Weapons.ShotGun] = Resources.Load<Sprite>(Constants.Resources.Sprites.Weapons.WeaponsPath + Constants.Resources.Sprites.Weapons.ShotGun);
    }
    public Sprite GetSprite(string SpriteName)
    {
        return LoadedSprite[SpriteName];
    }
}