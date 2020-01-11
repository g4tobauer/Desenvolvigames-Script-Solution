using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public bool GetKey(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }

    public bool GetKeyDown(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }

    public bool GetKeyUp(KeyCode keyCode)
    {
        return Input.GetKeyUp(keyCode);
    }

    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    public void LookAtMousePosition(Transform refTransform)
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(refTransform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        refTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
