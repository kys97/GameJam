using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leveltext : MonoBehaviour
{
    public Text level;
    // Start is called before the first frame update
    /*
    void Start()
    {
         level = GetComponent<Text>();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Customer_term == 25)
        {
            level.text = "���̵� : ���� ���� ��";
        }
        else if (GameManager.Instance.Customer_term == 15)
        {
            level.text = "���̵� : �׳� ���� ��";
        }
        else if (GameManager.Instance.Customer_term == 7)
        {
            level.text = "���̵� : ���� ��";
        }
        else if (GameManager.Instance.Customer_term == 5)
        {
            level.text = "���̵� : �̻��� ��";
        }
    }
}
