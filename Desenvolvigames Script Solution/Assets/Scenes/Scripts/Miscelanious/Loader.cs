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
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        LoadedPrefab[Constants.Path.ProjectilesPath.IronProjectile] = Resources.Load<GameObject>(Constants.Path.ProjectilesPath.IronProjectile);
    }
    public GameObject GetPrefab(string prefabName)
    {
        return LoadedPrefab[prefabName];
    }

}