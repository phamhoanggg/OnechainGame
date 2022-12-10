using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : FastSingleton<Player>
{
    public float HP;
    public float curHP;
    [SerializeField] private Image HPfill;
    public float playerLevel;
    public float MaxEXP, CurrentEXP;
    public List<GameObject> UpgradedList;
    public int ShurikenLevel, SawLevel, RocketLevel, HealthLevel, SpeedLevel, ExpLevel;
    public float multiExp = 1;


    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHP <= 0)
        {
            OnDead();
        }
        if (curHP > HP)
        {
            curHP = HP;
        }
        if (this.gameObject)
        {
            HPfill.fillAmount = curHP / HP;
        }
        

        if (CurrentEXP >= MaxEXP)
        {
            GameController.instance.LevelUp();
        }
    }

    public void OnInit()
    {
        transform.position = new Vector3(0, 0, 20);
        curHP = HP;
        HPfill.fillAmount = 1;
        playerLevel = 1;
        CurrentEXP = 0;
        MaxEXP = 100;
        MapController.instance.MapParent.transform.position = new Vector3(0, 0, 5);
    }

    public void decreaseHP(float damage)
    {
        curHP -= damage;
    }

    public void IncreaseEXP(float exp)
    {
        CurrentEXP += exp * multiExp;
    }

    private void OnDead()
    {
        GameController.instance.PauseGame();
        GetComponent<PlayerMoving>().anim.SetTrigger("die");
        UI_Manager.instance.Screens[(int)UI_Manager.ScreenState.GamePlay].SetActive(false);
        UI_Manager.instance.ResultText.text = "DEFEATED!!!";
        UI_Manager.instance.Screens[(int)UI_Manager.ScreenState.Result].SetActive(true);

        foreach (var screen in UI_Manager.instance.Screens)
        {
            if (screen == UI_Manager.instance.Screens[(int)UI_Manager.ScreenState.Result])
            {
                screen.SetActive(true);
            }
            else
            {
                screen.SetActive(false);
            }
        }
        UI_Manager.instance.equippedList.SetActive(false);
    }
}
