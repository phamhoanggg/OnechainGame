using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public override void UpgradeEffect()
    {
        Player.instance.HP *= 1.5f;
        Player.instance.curHP = Player.instance.HP;
        Player.instance.HealthLevel++;    
        if (Player.instance.HealthLevel == 6)
        {
            UI_Manager.instance.Upgrades[3] = healHP;
        }
    }
}
