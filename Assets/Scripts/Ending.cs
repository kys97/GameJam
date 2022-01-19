using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        bg.GetComponent<Image>().sprite = GameManager.Instance.Ending[GameManager.Instance.GetGameStatus() - 2];
    }

}
