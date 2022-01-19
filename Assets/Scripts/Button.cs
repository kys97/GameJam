using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public List<Sprite> Tutorials;
    public GameObject TutorialPannel;
    public GameObject LevelPannel;
    [SerializeField] private int TutorialPage = 0;

    public void Level()
    {
        LevelPannel.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void LoadTutorial()
    {
        TutorialPannel.SetActive(true);
        TutorialPage = 0;
        TutorialPannel.GetComponent<Image>().sprite = Tutorials[TutorialPage];
    }
    public void MJEgg()
    {

    }

    public void NextTutorial()
    {
        if (TutorialPage == 4)
            TutorialPannel.SetActive(false);
        else
        {
            TutorialPage++;
            TutorialPannel.GetComponent<Image>().sprite = Tutorials[TutorialPage];
        }
    }

    public void Level1()
    {
        GameManager.Instance.Customer_Second = 20;
        SceneManager.LoadScene("Game");
    }
    public void Level2()
    {
        GameManager.Instance.Customer_Second = 10;
        SceneManager.LoadScene("Game");
    }
    public void Level3()
    {
        GameManager.Instance.Customer_Second = 5;
        SceneManager.LoadScene("Game");
    }
    public void Level4()
    {
        GameManager.Instance.Play_minute = 1;
        GameManager.Instance.Customer_Second = 5;
        SceneManager.LoadScene("Game");
    }
}
