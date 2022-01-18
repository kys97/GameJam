using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [SerializeField] Button startPause;
    bool pauseActive = false;

    public void pauseBtn()
    { 
        if (pauseActive)
        {
            pauseActive = false;
            Time.timeScale = 1;
        }
        else
        {
            pauseActive = true;
            Time.timeScale = 0;
        }

    }

}