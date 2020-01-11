using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chinelo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 Position { get { return transform.position; } }
    public LayerMask ChineloMask { get { return LayerMask.NameToLayer(Constants.Layers.Chinelo); } }
}
