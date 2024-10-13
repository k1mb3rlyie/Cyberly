using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageNavigator
{
    private Lesson1 lesson;
    private int currentPageIndex;

    public PageNavigator(Lesson1 lesson)
    {
        this.lesson = lesson;
        currentPageIndex = 0;
    }

    public void NextPage()
    {
        if (currentPageIndex < lesson.Pages.Count - 1)
        {
            currentPageIndex++;
        }
        else
        {
            SceneManager.LoadSceneAsync(7);
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
        }
    }

    public int GetCurrentPageIndex()
    {
        return currentPageIndex;
    }

    public Lesson1.Page GetCurrentPage()
    {
        return lesson.Pages[currentPageIndex];
    }
}