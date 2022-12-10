using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHP : Upgrade
{
    public override void UpgradeEffect()
    {
        Player.instance.curHP += 100;
    }
}
