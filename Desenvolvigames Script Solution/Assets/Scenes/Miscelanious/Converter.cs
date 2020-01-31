using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter
{
    public static int LayerMaskToInt(LayerMask layerMask)
    {
        return Mathf.RoundToInt(Mathf.Log(layerMask, 2));
    }
}
