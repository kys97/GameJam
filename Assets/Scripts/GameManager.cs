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

    public bool CustomerFull = false;//손님 다 찼는지
    public List<int> Seat;//좌석
    public List<int> Menu;//메뉴
    public int[] menuNumber = { 1, 2, 4, 5, 7, 8 };
    public int[] poisonNumber = { 10, 11, 13, 14, 16, 17 };

    public int Play_minute;
    public float play_time;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
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
                    Debug.Log("싱글톤 안됌");
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

        for(int i=0; i < Assassin.Length; i++)
        {
            Assassin[i] = Random.Range(0, 24);

            for(int j=0; j < i; j++)
            {
                if(Assassin[j] == Assassin[i])
                {
                    i--;
                    break;
                }
            }

        }

        SceneManager.LoadScene("Game");
    }
    public void GameClear() { GameStatus = 2; }
    public void GameTimeOver() { GameStatus = 3; }
    public void GameDie() { GameStatus = 4; }
    public int GetGameStatus() { return GameStatus; }

    public void SetMoney(int m) { Money += m; }
    public int GetMoney() { return Money; }
}
