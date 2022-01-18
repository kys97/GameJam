using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        img.sprite = CurrentSprite;
    }

    public void ISelectHandler()
    {
        img.sprite = NextSprite;
    }

    public void IDeselectHandler()
    {
        img.sprite = CurrentSprite;
    }
}
