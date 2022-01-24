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
    private AudioSource theAudio;

    private void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

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

        GameManager.Instance.PrintTutorialClip();

        TutorialPage = 0;
        TutorialPannel.GetComponent<Image>().sprite = Tutorials[TutorialPage];
    }
    public void MJEgg()
    {
        theAudio.Play();
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
        GameManager.Instance.Customer_term = 25;
        GameManager.Instance.GameStart();
    }
    public void Level2()
    {
        GameManager.Instance.Play_minute = 2f;
        GameManager.Instance.Customer_Second = 10;
        GameManager.Instance.Customer_term = 15;
        GameManager.Instance.GameStart();
    }
    public void Level3()
    {
        GameManager.Instance.Play_minute = 1.5f;
        GameManager.Instance.Customer_Second = 9;
        GameManager.Instance.Customer_term = 7;
        GameManager.Instance.GameStart();
    }
    public void Level4()
    {
        GameManager.Instance.Play_minute = 1.5f;
        GameManager.Instance.Customer_Second = 7;
        GameManager.Instance.Customer_term = 5;
        GameManager.Instance.GameStart();
    }
}
