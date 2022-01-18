using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plating : MonoBehaviour
{
    [SerializeField] private int Index;
    private SpriteRenderer renderer;
    public int food = -1;
    public bool isPoison = false;
    public Sprite[] sprites = new Sprite[18];

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (food != -1)
        {
            GameManager.Instance.Menu[Index] = food;
            renderer.sprite = sprites[food];
            StartCoroutine(MenuClear());
            food = -1;
        }
    }

    public IEnumerator MenuClear()
    {
        yield return new WaitForSeconds(1.0f);
        renderer.sprite = null;
    }
}
