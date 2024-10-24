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
    public GameObject SignInPage;// the more panels i add the more complex this all gets
    public GameObject Passwerd;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true); //main menu start of the scene
        SettingsPanel.SetActive(false); //settings
        AchievementsPnl.SetActive(false); //achievements
        RegUser.SetActive(false); 
        LoginUser.SetActive(false);
        LeaderB.SetActive(false);
        SignInPage.SetActive(false);
        Passwerd.SetActive(false);
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

    public void NewUserBaby() //function in the signin/signup page to take you to user user registtration
    {
        SignInPage.SetActive(false);
        RegUser.SetActive(true);
        //MainMenuPanel.SetActive(false); keep this for now
    }
   
    public void OldUserYeah()
    {
        SignInPage.SetActive(false);
        LoginUser.SetActive(true);
        Passwerd.SetActive(false);
        //MainMenuPanel.SetActive(false); will already be disabled?
    }

    public void User()  //function to open up the signin/signup page user management
    {
        SignInPage.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void LeaderBaby()
    {
        LeaderB.SetActive(true);
        MainMenuPanel.SetActive(false); //mwahahahahaahha. nothing cant be solved with patience!!!!!!!!!!!!!!!!!1
    }

    public void ChangePassword()
    {
        LoginUser.SetActive(false);
        Passwerd.SetActive(true);
    }

    public void BackToSigninOptions() //and then from there load menu again

    {
        SignInPage.SetActive(true);
        LoginUser.SetActive(false);
        RegUser.SetActive(false);
        Passwerd.SetActive(false);
    }




    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
