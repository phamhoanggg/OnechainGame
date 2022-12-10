using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpgrade : Upgrade
{
    [SerializeField] private GameObject saw;
    [SerializeField] private SawEquip sawEquipPref;

    public override void UpgradeEffect()
    {
        SawEquip sawEquip = FindObjectOfType<SawEquip>();
        if (sawEquip == null)
        {
            Player.instance.SawLevel = 1;
            sawEquip = Instantiate(sawEquipPref);
        }
        else
        {
            Player.instance.SawLevel++;
            sawEquip.GetComponent<SawEquip>().sawPref.GetComponent<Saw>().damage += 5;
            sawEquip.GetComponent<SawEquip>().sawNumber++;
            sawEquip.GetComponent<SawEquip>().SpawnSaw();
            if (Player.instance.SawLevel == 6)
            {
                UI_Manager.instance.Upgrades[1] = healHP;
            }
        }
        
    }
}
