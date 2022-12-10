using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpUpgrade : Upgrade
{
    public override void UpgradeEffect()
    {
        Player.instance.multiExp *= 1.2f;
        Player.instance.ExpLevel++;
        if (Player.instance.ExpLevel == 6)
        {
            UI_Manager.instance.Upgrades[4] = healHP;
        }
    }
}
