using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


//script for managing 
public class MainMenuManager : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MainMenuPanel;
    public GameObject AchievementsPnl;
    public GameObject RegUser;
    public GameObject LeaderB;
    public GameObject LoginUser; 



    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        AchievementsPnl.SetActive(false);
        RegUser.SetActive(false);
        LoginUser.SetActive(false);
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
        RegUser.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
   
    public void LoginYeah()
    {
        LoginUser.SetActive(true);
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
