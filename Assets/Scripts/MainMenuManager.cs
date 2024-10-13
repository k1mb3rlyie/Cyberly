using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//script for managing 
public class MainMenuManager : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MainMenuPanel;
    public GameObject AchievementsPnl;

    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
        AchievementsPnl.SetActive(false);
    }

    public void LoadSetting()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void AchieveBaby()
    {
        AchievementsPnl.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
