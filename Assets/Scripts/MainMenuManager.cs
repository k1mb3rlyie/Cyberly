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
    public GameObject User;
    public GameObject LeaderB;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        AchievementsPnl.SetActive(false);
        User.SetActive(false);
        LeaderB.SetActive(false);

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

    public void UserBaby()
    {
        User.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void LeaderBaby()
    {
        LeaderB.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
