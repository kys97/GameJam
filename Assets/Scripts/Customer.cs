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
                killerNum = i;
                MyMenu = GameManager.Instance.poisonNumber[index];
            }
        }

        GameManager.Instance.customer_time = GameManager.Instance.Customer_Second;
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
            MyTimer.value = GameManager.Instance.customer_time / GameManager.Instance.Customer_Second;
            if (GameManager.Instance.customer_time > 0.0f) GameManager.Instance.customer_time -= Time.deltaTime;
            else GameManager.Instance.customer_time = 0;

            if (MyTimer.value <= 0.0f)//�ֹ� �� �ް� Ÿ�̸� ����
            {
                if (isKiller) GameManager.Instance.GameDie();
                GameManager.Instance.play_time -= 3.0f;
                GameManager.Instance.Seat[Index] = -1;
                GameManager.Instance.Menu[Index] = -1;
                TimerStop = true;
                MyTimer.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if (GameManager.Instance.Menu[Index] == MyMenu)//�ֹ� ����� �޾��� ��
            {
                
                if (isKiller)
                {
                    Debug.Log(Index + "ų�� ����");
                    GameManager.Instance.SetMoney(15000);//ų�� ���̸� �� ����
                    GameManager.Instance.People.Remove(GameManager.Instance.People[Number]);//ų�� ������ �մ� ����Ʈ���� ����
                    GameManager.Instance.Assassin[killerNum] = -1;
                }
                else
                {
                    Debug.Log(Index + "�ֹ� �� ����");
                    GameManager.Instance.SetMoney(5000);
                }
                GameManager.Instance.Seat[Index] = -1;
                GameManager.Instance.Menu[Index] = -1;
                Debug.Log(Index + "�ֹ� �� ���� ����");
                TimerStop = true;
                MyTimer.gameObject.SetActive(false);
                StartCoroutine(MenuClear());
            }
            else if (GameManager.Instance.Menu[Index] != -1)//�ֹ� �߸� �޾��� ��
            {
                Debug.Log(Index+ "�ֹ� �߸�����");
                if (isKiller) { GameManager.Instance.GameDie(); Debug.Log("ų�� �߸�����"); }
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
