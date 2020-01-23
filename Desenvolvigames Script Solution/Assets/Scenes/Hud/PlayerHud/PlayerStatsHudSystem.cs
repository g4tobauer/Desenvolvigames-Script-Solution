using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsHudSystem : MonoBehaviour
{
    public HudSystem HudSystem;
    public Text HudHealthText;
    public Text HudStoredAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HudHealthText.text = HudSystem.HudHealth.ToString();
        HudStoredAmmoText.text = HudSystem.HudStoredAmmo.ToString();
    }
}
