using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    Slider Timer;
    public int GameTime;
    float MaxTime;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = GameManager.Instance.Play_minute;
        Timer = GetComponent<Slider>();
        MaxTime = GameTime * 60;
        GameManager.Instance.play_time = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.value = GameManager.Instance.play_time / MaxTime;
        if (GameManager.Instance.play_time > 0.0f) GameManager.Instance.play_time -= Time.deltaTime;
        else GameManager.Instance.play_time = 0;
        
        if(Timer.value <= 0)
        {
            if(GameManager.Instance.GetMoney() <= GameManager.Instance.TargetAmount)
            {
                GameManager.Instance.GameClear();
                SceneManager.LoadScene("End");
            }
            else
            {
                GameManager.Instance.GameTimeOver();
                SceneManager.LoadScene("End");
            }
        }
    }
}
