using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    [SerializeField] private List<GameObject> Killers;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.Instance.Assassin.Length; i++)
            Killers[i].GetComponent<SpriteRenderer>().sprite = GameManager.Instance.People[GameManager.Instance.Assassin[i]];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (GameManager.Instance.Assassin[i] == -1)
            {
                GameManager.Instance.RandomKiller(i);
                Killers[i].GetComponent<SpriteRenderer>().sprite = GameManager.Instance.People[GameManager.Instance.Assassin[i]];
                Debug.Log("인덱스 : "+i+" / 새로운 킬러 : " + GameManager.Instance.Assassin[i]);
            }
        }
    }
}
