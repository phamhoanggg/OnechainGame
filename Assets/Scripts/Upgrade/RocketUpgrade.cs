using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpgrade : Upgrade
{
    [SerializeField] private RocketEquip rkEquipPref;
    public override void UpgradeEffect()
    {
        RocketEquip rkEquip = FindObjectOfType<RocketEquip>();
        if (rkEquip == null)
        {
            rkEquip = Instantiate(rkEquipPref);
            Player.instance.RocketLevel = 1;
        }
        else
        {
            Player.instance.RocketLevel++;
            switch (Player.instance.RocketLevel)
            {
                case 2:
                    {
                        rkEquip.rocket.GetComponent<Rocket>().damage += 10;
                        break;
                    }
                case 3:
                    {
                        rkEquip.rocket.GetComponent<Rocket>().damage += 10;
                        rkEquip.rocket.GetComponent<Rocket>().explodeRadius += 1;
                        break;
                    }
                case 4:
                    {
                        rkEquip.rocket.GetComponent<Rocket>().damage += 10;
                        break;
                    }
                case 5:
                    {
                        rkEquip.rocket.GetComponent<Rocket>().damage += 10;
                        rkEquip.rocket.GetComponent<Rocket>().explodeRadius += 1;
                        break;
                    }
                case 6:
                    {
                        rkEquip.rocket.GetComponent<Rocket>().damage += 10;
                        UI_Manager.instance.Upgrades[2] = healHP;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
