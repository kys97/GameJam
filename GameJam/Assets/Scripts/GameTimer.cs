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
    float SliderTime;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = GameManager.Instance.PlayTime;
        Timer = GetComponent<Slider>();
        MaxTime = GameTime * 60;
        SliderTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.value = SliderTime / MaxTime;
        if (SliderTime > 0.0f) SliderTime -= Time.deltaTime;
        else SliderTime = 0;
        
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
