using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //0 게임 시작 전, 1 게임 중, 2 게임 성공, 3 타임어택 실패, 4 암살 대상 못 죽임
    [SerializeField] private int GameStatus = 0;
    [SerializeField] private int Money;
    public int TargetAmount = 250000;
    public List<Sprite> People;
    public int[] Assassin = new int[5];
    public List<Sprite> Bottles;
    public List<Sprite> Ending;

    public bool CustomerFull = false;//손님 다 찼는지
    public List<int> Seat;//좌석
    public List<int> Menu;//메뉴
    public int[] menuNumber = { 1, 2, 4, 5, 7, 8 };
    public int[] poisonNumber = { 10, 11, 13, 14, 16, 17 };

    public float Play_minute;
    public float play_time;
    public int Customer_Second;
    public float customer_time;
    public float Customer_term;

    [Header("- Sound")]
    private AudioSource theAudio;
    public AudioClip StartClip;
    public AudioClip TtClip;
    public AudioClip ClearClip;
    public AudioClip OverClip;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        theAudio = GetComponent<AudioSource>();

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("싱글톤 안됨");
            }

            return _instance;
        }
    }

    private void Update()
    {
        int cnt = 0;
        for (int i = 0; i < Seat.Count; i++)
            if (Seat[i] >= 0)
                cnt++;

        if (cnt == 4)
            CustomerFull = true;
        else
            CustomerFull = false;
    }

    public void GameStart() 
    {
        GameStatus = 1;
        Money = 0;

        for (int i = 0; i < Assassin.Length; i++)
            RandomKiller(i);

        theAudio.clip = StartClip;
        theAudio.Play();

        SceneManager.LoadScene("Game"); 
    }

    public void PrintTutorialClip()
    {
        theAudio.clip = TtClip;
        theAudio.Play();

    }

    public void RandomKiller(int i)
    {
        bool check = true;
        while(check)
        {
            check = false;
            Assassin[i] = Random.Range(0, 25);

            for (int j = 0; j < Assassin.Length; j++)
            {
                if (j != i && Assassin[j] == Assassin[i])
                {
                    check = true;
                    Assassin[i] = -1;
                    break;
                }
            }
        }
    }

    public void GameClear()
    { 
        GameStatus = 2;
        theAudio.clip = ClearClip;
        theAudio.Play();
        GameEnding(); 
    }
    public void GameTimeOver()
    { 
        GameStatus = 3;
        theAudio.clip = OverClip;
        theAudio.Play();
        GameEnding(); 
    }
    public void GameDie() 
    { 
        GameStatus = 4;
        theAudio.clip = OverClip;
        theAudio.Play();
        GameEnding();
    }
    public int GetGameStatus() { return GameStatus; }
    public void GameEnding() 
    { SceneManager.LoadScene("End"); }

    public void SetMoney(int m) { Money += m; }
    public int GetMoney() { return Money; }
}
