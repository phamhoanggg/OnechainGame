using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public override void UpgradeEffect()
    {
        Player.instance.GetComponent<PlayerMoving>().speed *= 1.1f;
        Player.instance.SpeedLevel++;
        if (Player.instance.SpeedLevel == 6)
        {
            UI_Manager.instance.Upgrades[5] = healHP;
        }
    }
}
