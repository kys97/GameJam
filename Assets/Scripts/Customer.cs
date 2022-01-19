using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private Slider MyTimer;
    private int Number;
    [SerializeField] private int Index;
    [SerializeField] private int MyMenu;
    public bool isKiller = false;
    private int killerNum = -1;
    [SerializeField] private GameObject menu_img;
    private bool init = false;
    bool TimerStop = false;

    [Header("- Sound")]
    private AudioSource theAudio;
    public AudioClip SuccessClip;
    public AudioClip FailClip;
    public AudioClip BombClip;

    private int Maxtime = GameManager.Instance.Customer_Second;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 5);
        MyMenu = GameManager.Instance.menuNumber[index];
        menu_img.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Bottles[MyMenu];
        theAudio = GetComponent<AudioSource>();

        for (int i=0; i < 3; i++)
        {
            if (GameManager.Instance.Assassin[i] == Number)
            {
                isKiller = true;
                killerNum = i;
                MyMenu = GameManager.Instance.poisonNumber[index];
            }
        }

        time = Maxtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (init)
        {
            ManageCustomer();
        }
    }

    public void setInit(int n, Slider t, int i)
    {
        Number = n;
        MyTimer = t;
        Index = i;
        init = true;
    }

    private void ManageCustomer()
    {
        if (!TimerStop)
        {
            MyTimer.value = time / Maxtime;
            if (time > 0.0f) time -= Time.deltaTime;
            else time = 0;

            if (MyTimer.value <= 0.0f)//주문 못 받고 타이머 종료
            {
                if (isKiller) GameManager.Instance.GameDie();
                GameManager.Instance.play_time -= 3.0f;
                GameManager.Instance.Seat[Index] = -1;
                GameManager.Instance.Menu[Index] = -1;
                TimerStop = true;
                MyTimer.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if (GameManager.Instance.Menu[Index] == MyMenu)//주문 제대로 받았을 때
            {
                
                if (isKiller)
                {
                    Debug.Log(Number + "킬러 죽임");
                    GameManager.Instance.SetMoney(15000);//킬러 죽이면 돈 더줌
                    GameManager.Instance.Assassin[killerNum] = -1;
                }
                else
                {
                    Debug.Log(Number + "주문 잘 받음");
                    GameManager.Instance.SetMoney(5000);
                }
                GameManager.Instance.Seat[Index] = -1;
                GameManager.Instance.Menu[Index] = -1;
                Debug.Log(Number + "주문 잘 받은 이후");

                theAudio.clip = SuccessClip;
                theAudio.Play();

                TimerStop = true;
                MyTimer.gameObject.SetActive(false);
                StartCoroutine(MenuClear());
            }
            else if (GameManager.Instance.Menu[Index] != -1)//주문 잘못 받았을 때
            {
                Debug.Log(Number + "주문 잘못받음");
                if (isKiller) 
                { 
                    GameManager.Instance.GameDie(); Debug.Log(Number + " 킬러 잘못받음");
                    theAudio.clip = BombClip;
                    theAudio.Play();
                }
                else
                {
                    theAudio.clip = FailClip;
                    theAudio.Play();
                }
                GameManager.Instance.Seat[Index] = -1;
                GameManager.Instance.Menu[Index] = -1;
                TimerStop = true;
                MyTimer.gameObject.SetActive(false);
                StartCoroutine(MenuClear());
            }
        }
    }

    public IEnumerator MenuClear()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
