using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private int Number;
    private int menu;
    [SerializeField] private GameObject menu_img;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameManager.Instance.menuNumber[Random.Range(0, 5)];
        menu_img.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Menu[menu];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumber(int n)
    {
        Number = n;
    }
}
