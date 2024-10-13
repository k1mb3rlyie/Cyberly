//GOD WILLING, THE ONLY TYPOS IN MY CODE WILLBE IN THE COMMENTS. Y'ALL KNOW MY ENGLIS HIS ATROCIOUS


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
    //technically the scene manager but since the main menu
    //has most of my scenes then i  will save them here
{



    // contains my scene manager and interface logic
    private int PreviousSceneIndex;

    /*public Lesson1 lesson1;*/  //im not even referencing this for any reason

    //i dotn even know what this block of code is for?
    //lol im going to comment it before its start giving me some wicjed issues



    public void LoadMap() 
    {
        SceneManager.LoadSceneAsync(1);

        //name of function insert index between parentheses the nmber one is to load the map scene
    }



    public void LoadLesson1()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(2);

    }
    public void LoadLesson2()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(3);
    }
    public void LoadLesson3()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(4);
    }
    public void LoadLesson4()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(5);
    }
    public void LoadLesson5()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(6);
    }




    //Quiz Scenes. i need to stop spelling
    //the word quiz as quizz. what am i? an illiterate?
    //haba

//att this point ypu can tell the code is just  repeating itslef

    public void LoadQuizz1()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(7);
    }
    public void LoadQuizz2()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(8);
    }
    public void LoadQuizz3()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(9);
    }

    public void LoadQuizz4()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(10);
    }
    public void LoadQuizz5()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(11);
    }






    public void LoadProgress()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(13); 
    }



    public void LoadResult()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(14);
    }


    public void LoadAchievements()
    {
        StoreCurrentScene();
        SceneManager.LoadSceneAsync(12);
    }




    public void CloseApp()
    {
        Application.Quit();
    }


    private void StoreCurrentScene() //capture scene
    {
        PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void BackButton()
    {
        SceneManager.LoadSceneAsync(PreviousSceneIndex);   //now ill attach this function to the back button in the game
    }



    //public void LoadOnAnswer()
    //{
    //    //SceneManager.LoadSceneAsync(); //lemme figure this out first because "ban gane" right now
    //    //scene management to move to the next quiz question will probably have to run till when there are no questions left then proceed to the next scene
    //} //currently buffering
}
