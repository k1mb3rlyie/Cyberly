using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LessonManager : MonoBehaviour
{
    public Lesson1 currentLesson; // Reference to the current lesson
    public Text lessonTitleText; // UI Text to display the lesson title
    public Text lessonContentText; // UI Text to display the lesson content
    private PageNavigator pageNavigator;

    void Start()
    {
        if (currentLesson != null)
        {
            pageNavigator = new PageNavigator(currentLesson);
            DisplayCurrentPage();
        }
    }

    public void DisplayCurrentPage()
    {
        if (pageNavigator != null)
        {
            Lesson1.Page currentPage = pageNavigator.GetCurrentPage();
            lessonTitleText.text = currentPage.PageTitle;
            lessonContentText.text = currentPage.PageContent;
        }
    }

    public void NextPage()
    {
        if (pageNavigator != null)
        {
            pageNavigator.NextPage();
            DisplayCurrentPage();
        }
    }

    public void PreviousPage()
    {
        if (pageNavigator != null)
        {
            pageNavigator.PreviousPage();
            DisplayCurrentPage();
        }
    }
}