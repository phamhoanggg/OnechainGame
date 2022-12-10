using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenUpgrade : Upgrade
{
 //   public GameObject shuriken;
    public override void UpgradeEffect()
    {
        GameObject shuriken = Player.instance.GetComponent<PlayerAttack>().shuriken;
        shuriken.GetComponent<Shuriken>().damage += 2;
        shuriken.transform.localScale *= 1.1f;
        Player.instance.ShurikenLevel++;
        if (Player.instance.ShurikenLevel == 6)
        {
            UI_Manager.instance.Upgrades[0] = healHP;
        }
    }
}
