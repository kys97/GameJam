using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seat : MonoBehaviour
{
    [SerializeField] private int SeatNumber;
    public GameObject CustomerPrefab;
    [SerializeField] private Slider Timer; 

    void Start()
    {
        StartCoroutine(SetCustomer());
    }

    private void Update()
    {
        if (GameManager.Instance.GetGameStatus() > 1)
            StopCoroutine(SetCustomer());
    }

    public IEnumerator SetCustomer()
    {
        if (GameManager.Instance.GetGameStatus() == 1) {

            yield return new WaitForSeconds(Random.Range(0.0f, GameManager.Instance.Customer_term));

            if (!GameManager.Instance.CustomerFull && GameManager.Instance.Seat[SeatNumber] == -1)
            {
                GameManager.Instance.Seat[SeatNumber] = Random.Range(0, 24);
                GameObject copy = Instantiate(CustomerPrefab, transform.position, Quaternion.identity);
                Timer.gameObject.SetActive(true);
                copy.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.People[GameManager.Instance.Seat[SeatNumber]];
                copy.GetComponent<Customer>().setInit(GameManager.Instance.Seat[SeatNumber], Timer, SeatNumber);
            }
        }
        yield return StartCoroutine(SetCustomer());
    }
}
