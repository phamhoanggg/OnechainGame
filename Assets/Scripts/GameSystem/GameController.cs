using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : FastSingleton<GameController>
{
    public enum GameState
    {
        Menu,
        GamePlay, 
        Pause,
        Result,
    }

    public float PlayTime = 0;
    public float coin;
    public float kills;
    public List<GameObject> UpgradePool;
    public GameObject[] Levels;
    public GameObject zombie;
    public GameState gameState;
    private GameObject currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.GamePlay)
        {
            PlayTime += Time.deltaTime;
            if (PlayTime >= 600)
            {
                gameState = GameState.Result;
                PlayTime = 0;
                PauseGame();
                UI_Manager.instance.ResultText.text = "VICTORY!!!";
                UI_Manager.instance.KillResultText.text = "Kill: " + kills.ToString();
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

        if (gameState == GameState.Menu)
        {
            CancelInvoke();
        }
        
    }

    public void LevelUp()
    {
        Player.instance.CurrentEXP = 0;
        Player.instance.MaxEXP += 50;
        Player.instance.playerLevel++;
        UI_Manager.instance.Invoke(nameof(UI_Manager.instance.DisplayLevelUp), 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameState = GameState.Pause;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameState = GameState.GamePlay;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
        CancelInvoke();
        StartGame();
    }

    public void SpawnEnemy()
    {
        Instantiate(zombie, new Vector3(Random.Range(Player.instance.transform.position.x - 60, Player.instance.transform.position.x + 60), 
                    Random.Range(Player.instance.transform.position.y - 60, Player.instance.transform.position.y + 60), 0), Quaternion.identity);
    }

    public void StartGame()
    {
        Player.instance.OnInit();
        PlayTime = 0;
        gameState = GameState.GamePlay;
        InvokeRepeating(nameof(SpawnEnemy), 0, 1f);
        foreach (var screen in UI_Manager.instance.Screens)
        {
            if (screen == UI_Manager.instance.Screens[(int)UI_Manager.ScreenState.GamePlay])
            {
                screen.SetActive(true);
            }
            else
            {
                screen.SetActive(false);
            }
        }
        UI_Manager.instance.equippedList.SetActive(false);
        ResumeGame();
    }
    
}
