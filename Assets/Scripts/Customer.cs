using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private Slider MyTimer;
    private int Number;
    private int Index;
    private int MyMenu;
    [SerializeField] private int maxtime = 5;
    private float time;
    public bool isKiller = false;
    [SerializeField] private GameObject menu_img;
    private bool init = false;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 5);
        MyMenu = GameManager.Instance.menuNumber[index];
        menu_img.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Bottles[MyMenu];

        for(int i=0; i < 3; i++)
        {
            if (GameManager.Instance.Assassin[i] == Number)
            {
                isKiller = true;
                MyMenu = GameManager.Instance.poisonNumber[index];
            }
        }
        time = maxtime;
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
        MyTimer.value = time / maxtime;
        if (time > 0.0f) time -= Time.deltaTime;
        else time = 0;

        if (MyTimer.value <= 0.0f)//주문 못 받고 타이머 종료
        {
            GameManager.Instance.play_time -= 3.0f;
            GameManager.Instance.Seat[Index] = -1;
            MyTimer.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (GameManager.Instance.Menu[Index] == MyMenu)//주문 제대로 받았을 때
        {
            GameManager.Instance.Seat[Index] = -1;
            GameManager.Instance.SetMoney(5000);
            MyTimer.gameObject.SetActive(false);
            StartCoroutine(MenuClear());
        }
        else if (GameManager.Instance.Menu[Index] != -1)//주문 잘못 받았을 때
        {
            GameManager.Instance.Seat[Index] = -1;
            MyTimer.gameObject.SetActive(false);
            StartCoroutine(MenuClear());
        }
    }
    public IEnumerator MenuClear()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
