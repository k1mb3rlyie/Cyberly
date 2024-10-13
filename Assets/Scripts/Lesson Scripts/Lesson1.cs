using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Lesson", menuName = "Lessons/Lesson")]
public class Lesson1 : ScriptableObject
{
    public string Title; // Title of the lesson
    [TextArea(3, 10)] // Allows for multi-line input in the inspector
    public string Content; // The content of the lesson
    public List<Page> Pages; // List of pages

    [System.Serializable]
    public class Page
    {
        public string PageTitle; // Title for the page
        [TextArea(3, 10)]
        public string PageContent; // Content for the page

        public void Validate()
        {
            if (string.IsNullOrEmpty(PageTitle))
            {
                throw new ArgumentException("Page title cannot be empty.");
            }
        }
    }

    public void AddPage(Page page)
    {
        Pages.Add(page);
        page.Validate();
    }
}