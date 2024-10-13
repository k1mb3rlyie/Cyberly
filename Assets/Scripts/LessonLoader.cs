using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LessonPanel1.SetActive(false);
        LessonPanel2.SetActive(false);
        LessonPanel3.SetActive(false);
        LessonPanel4.SetActive(false);
        LessonPanel5.SetActive(false);
        LessonPanel6.SetActive(false);


        PagePanel1.SetActive(false);
        PagePanel2.SetActive(false);
        PagePanel3.SetActive(false);
        PagePanel4.SetActive(false);
        PagePanel5.SetActive(false);
        PagePanel6.SetActive(false);
        PagePanel7.SetActive(false);
        PagePanel8.SetActive(false);
        PagePanel9.SetActive(false);
        PagePanel10.SetActive(false);
        PagePanel11.SetActive(false);
        PagePanel12.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }


    //MORE GAME OBJECTS YAY!!! (sometimes i wonder if (i will ever finish this app)

    public GameObject LessonPanel1;
    public GameObject LessonPanel2;
    public GameObject LessonPanel3;
    public GameObject LessonPanel4;
    public GameObject LessonPanel5;
    public GameObject LessonPanel6;

    public GameObject PagePanel1;
    public GameObject PagePanel2;
    public GameObject PagePanel3;
    public GameObject PagePanel4;
    public GameObject PagePanel5;
    public GameObject PagePanel6;
    public GameObject PagePanel7;
    public GameObject PagePanel8;
    public GameObject PagePanel9;
    public GameObject PagePanel10;
    public GameObject PagePanel11;
    public GameObject PagePanel12; //DONE!!

    //ASSIGNING THOSE PANELS WAS A BITCH


    // so basically this is the best way in my head to execute this
    //that is to  amke diffferent functions for (different leassons
    //the scene manager will still load the same scene but i will have
    //different lessons on different panel
    //i  will set the correct lesson panel to active when clicked


    private int PreviousSceneIndex;
    public void LoadLesson1()
    {
        StoreCurrentScene();              // capture the previous scen index before loading the next
        SceneManager.LoadSceneAsync(2);
        LessonPanel1.SetActive(true);
        PagePanel1.SetActive(true);     //this will be the same fuction for my back button
                                        //so i dont have to write new logic like a mad man
        PagePanel2.SetActive(false);
    } // don't forget to load funtion  into button


    //bruh it looks like thsi page will have a lot of funtions
    public void P2L1()
    {
        LessonPanel1.SetActive(true);
        PagePanel1.SetActive(false);
        PagePanel2.SetActive(true);
    }


    public void LoadLesson2()
    {
        StoreCurrentScene();              // capture the previous scene index before loading the next
        SceneManager.LoadSceneAsync(2);

        LessonPanel2.SetActive(true);
        PagePanel3.SetActive(true);
        PagePanel4.SetActive(false);
    }

    public void P2L2()
    {
        LessonPanel2.SetActive(true);
        PagePanel3.SetActive(false);
        PagePanel4.SetActive(true);
    }

    public void LoadLesson3()
    {
        StoreCurrentScene();              // capture the previous scene index before loading the next
        SceneManager.LoadSceneAsync(2);
        LessonPanel3.SetActive(true);
        PagePanel5.SetActive(true);
        PagePanel6.SetActive(false);

    }
    public void P2L3()
    {
        LessonPanel3.SetActive(true);
        PagePanel5.SetActive(false);
        PagePanel6.SetActive(true);
    }
    public void LoadLesson4()
    {
        StoreCurrentScene();              // capture the previous scene index before loading the next
        SceneManager.LoadSceneAsync(2);
        LessonPanel4.SetActive(true);
        PagePanel7.SetActive(true);
        PagePanel8.SetActive(false);

    }

    public void P2L4()
    {
        LessonPanel4.SetActive(true);
        PagePanel7.SetActive(false);
        PagePanel8.SetActive(true);
    }

    public void LoadLesson5()
    {
        StoreCurrentScene();              // capture the previous scene index before loading the next
        SceneManager.LoadSceneAsync(2);
        LessonPanel5.SetActive(true);
        PagePanel9.SetActive(true);
        PagePanel10.SetActive(false);
    }

    public void P2L5()
    {
        LessonPanel5.SetActive(true);
        PagePanel9.SetActive(false);
        PagePanel10.SetActive(true);
    }
    public void LoadLesson6()
    {
        StoreCurrentScene();              // capture the previous scene index before loading the next one
        SceneManager.LoadSceneAsync(2);
        LessonPanel6.SetActive(true);
        PagePanel11.SetActive(true);
        PagePanel12.SetActive(false);
    }

    public void P2L6()
    {
        LessonPanel6.SetActive(true);
        PagePanel11.SetActive(false);
        PagePanel12.SetActive(true);
    }



    private void StoreCurrentScene() //capture scene
    {
        PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    //we might be her till next year

}


