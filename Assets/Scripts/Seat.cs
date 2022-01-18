using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public GameObject CustomerPrefab;

    void Start()
    {
        StartCoroutine(SetCustomer());
    }

    private void Update()
    {
        if (GameManager.Instance.GetGameStatus() != 1)
            StopCoroutine(SetCustomer());
    }

    public IEnumerator SetCustomer()
    {
        while (GameManager.Instance.GetGameStatus() == 1) {
            if (!GameManager.Instance.CustomerFull)
            {
                for(int i = 0; i < GameManager.Instance.Seat.Length; i++)
                {
                    if(GameManager.Instance.Seat[i] == -1)
                    {
                        GameManager.Instance.Seat[i] = Random.Range(0, 24);
                        GameObject copy = Instantiate(CustomerPrefab, transform.position, Quaternion.identity);
                        copy.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.People[GameManager.Instance.Seat[i]];
                        copy.GetComponent<Customer>().setNumber(GameManager.Instance.Seat[i]);
                    }
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
        yield return null;
    }
}
