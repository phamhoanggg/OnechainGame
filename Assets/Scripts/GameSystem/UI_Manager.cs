using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : FastSingleton<UI_Manager>
{
    public enum ScreenState
    {
        MainMenu = 0,
        Loading,
        GamePlay,
        LevelUp,
        PauseGame,
        Result,
    }

    public enum UpgradeState
    {
        Shuriken,
        Saw,
        Missle,
    }

    [SerializeField] private Image LoadingFill;
    [SerializeField] private Text LoadingText;
    [SerializeField] private Text TimeText;
    [SerializeField] private Text CoinText;
    [SerializeField] private Text KillsText;
    [SerializeField] private Text LevelText;
    [SerializeField] private Image Exp;
    public Text ResultText;
    public Text KillResultText;
    public GameObject[] Screens;
    public List<GameObject> Upgrades;
    public GameObject equippedList;
    [SerializeField] private Button Upgrade1, Upgrade2, Upgrade3;

    // Start is called before the first frame update
    void Start()
    {
        Screens[(int)ScreenState.Loading].SetActive(true);
        LoadingFill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadingFill.fillAmount < 1)
        {
            if (Screens[(int)ScreenState.Loading].activeInHierarchy)
                LoadingFill.fillAmount += Time.deltaTime / 2;
        }
        else
        {
            Screens[(int)ScreenState.Loading].SetActive(false);
            Screens[(int)ScreenState.MainMenu].SetActive(true);
            LoadingFill.fillAmount = 0;
        }
        LoadingText.text = ((int)(LoadingFill.fillAmount * 100)).ToString() + "%";

        TimeText.text = ((int)(GameController.instance.PlayTime / 60) < 10 ? "0" : null) + (int)(GameController.instance.PlayTime / 60) + " : " + ((int)(GameController.instance.PlayTime % 60) < 10 ? "0" : null) + (int)(GameController.instance.PlayTime % 60);
        CoinText.text = GameController.instance.coin.ToString();
        KillsText.text = GameController.instance.kills.ToString();
        LevelText.text = Player.instance.playerLevel.ToString();
        Exp.fillAmount = (Player.instance.CurrentEXP) * 1.0f / (Player.instance.MaxEXP);
    }

    public void ClickPauseBtn()
    {
        GameController.instance.PauseGame();
        equippedList.SetActive(true);
        Screens[(int)ScreenState.PauseGame].SetActive(true);
    }

    public void ClickResumeBtn()
    {
        GameController.instance.ResumeGame();
        equippedList.SetActive(false);
        Screens[(int)ScreenState.PauseGame].SetActive(false);
    }

    public void ClickHomeBtn()
    {
        GameController.instance.gameState = GameController.GameState.Menu;
        Screens[(int)ScreenState.PauseGame].SetActive(false);
        Screens[(int)ScreenState.GamePlay].SetActive(false);
        Screens[(int)ScreenState.Result].SetActive(false);
        equippedList.SetActive(false);
        Screens[(int)ScreenState.MainMenu].SetActive(true);
        GameController.instance.PlayTime = 0;
        GameController.instance.coin = 0;
        GameController.instance.kills = 0;

    }

    public void ClickReplayButton()
    {
        Player.instance.OnInit();
        Screens[(int)ScreenState.Result].SetActive(false);
        GameController.instance.ReplayGame();
        GameController.instance.coin = 0;
        GameController.instance.kills = 0;
    }

    public void ClickPlayButton()
    {
        Screens[(int)ScreenState.MainMenu].SetActive(false);
        Screens[(int)ScreenState.GamePlay].SetActive(true);
        Invoke(nameof(DisplayLevelUp), 1);
        GameController.instance.StartGame();
    }

    public void ClickQuitBtn()
    {
        Application.Quit();
    }

    public void ClickUpgrade1Button()
    {
        Upgrade1.GetComponentInChildren<Upgrade>().UpgradeEffect();
        AddIconUpgrade(Upgrade1);
        HideLevelUp();
    }

    public void ClickUpgrade2Button()
    {
        Upgrade2.GetComponentInChildren<Upgrade>().UpgradeEffect();
        AddIconUpgrade(Upgrade2);
        HideLevelUp();
    }

    public void ClickUpgrade3Button()
    {
        Upgrade3.GetComponentInChildren<Upgrade>().UpgradeEffect();
        AddIconUpgrade(Upgrade3);
        HideLevelUp();
    }

    public void DisplayLevelUp()
    {
        GameController.instance.PauseGame();
        equippedList.SetActive(true);
        Screens[(int)ScreenState.LevelUp].SetActive(true);
        int num1, num2, num3;
        num1 = Random.Range(0, Upgrades.Count);
        do
        {
            num2 = Random.Range(0, Upgrades.Count);
        } while (num2 == num1);

        do
        {
            num3 = Random.Range(0, Upgrades.Count);
        } while (num3 == num1 || num3 == num2);

        Instantiate(Upgrades[num1], Upgrade1.transform);
        Instantiate(Upgrades[num2], Upgrade2.transform);
        Instantiate(Upgrades[num3], Upgrade3.transform);
    }

    private void HideLevelUp()
    {
        Debug.Log("Click");
        Upgrade[] upgrades = FindObjectsOfType<Upgrade>();
        foreach(var upgrade in upgrades)
        {
            Destroy(upgrade.gameObject);
        }
        equippedList.SetActive(false);
        Screens[(int)ScreenState.LevelUp].SetActive(false);
        GameController.instance.ResumeGame();
    }

    private void AddIconUpgrade(Button upgrade)
    {
        Image[] icons = equippedList.GetComponentsInChildren<Image>();
        foreach(var icon in icons)
        {
            if (icon.sprite == null)
            {
                icon.sprite = upgrade.GetComponentInChildren<Upgrade>().icon;
                break;
            }
            else
            {
                if (icon.sprite == upgrade.GetComponentInChildren<Upgrade>().icon)
                {
                    break;
                }
                continue;
            }
        }
    }
}
