using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public int state = -1;
    public bool isPoison = false;
    public GameObject target;
    private SpriteRenderer renderer;
    public Sprite[] sprites = new Sprite[18];
    
    Plating plating;
    GameManager gamemanager;

    [Header("- Money")]


    [Header("- Sound")]
    private AudioSource theAudio;
    [SerializeField] protected AudioClip b1;
    [SerializeField] protected AudioClip b2;
    [SerializeField] protected AudioClip b3;
    [SerializeField] protected AudioClip milk;
    [SerializeField] protected AudioClip whiskey;
    [SerializeField] protected AudioClip poison;


    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        theAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;

                if (target.name == "B1")
                {
                    state = 0;
                    isPoison = false;
                    renderer.enabled = true;

                    theAudio.clip = b1;
                    theAudio.Play();
                }
                else if (target.name == "B2")
                {
                    state = 3;
                    isPoison = false;
                    renderer.enabled = true;

                    theAudio.clip = b2;
                    theAudio.Play();
                }
                else if (target.name == "B3")
                {
                    state = 6;
                    isPoison = false;
                    renderer.enabled = true;

                    theAudio.clip = b3;
                    theAudio.Play();
                }

                if (state % 3 == 0)
                {
                    if (target.name == "C1")
                    {
                        state += 1;

                        theAudio.clip = milk;
                        theAudio.Play();
                    }
                    else if (target.name == "C2")
                    {
                        state += 2;

                        theAudio.clip = whiskey;
                        theAudio.Play();
                    }
                }

                if (state != -1 && isPoison == false && target.name == "Poison")
                {
                    isPoison = true;
                    state += 9;

                    theAudio.clip = poison;
                    theAudio.Play();
                }

                //음료 제공
                if (target.name == "P1")
                {
                    plating = GameObject.Find("P1").GetComponent<Plating>();
                    Serving();
                }
                else if (target.name == "P2")
                {
                    plating = GameObject.Find("P2").GetComponent<Plating>();
                    Serving();
                }
                else if (target.name == "P3")
                {
                    plating = GameObject.Find("P3").GetComponent<Plating>();
                    Serving();
                }
                else if (target.name == "P4")
                {
                    plating = GameObject.Find("P4").GetComponent<Plating>();
                    Serving();
                }
            }
        }

        if (state != -1)
        {
            renderer.sprite = sprites[state];
        }

        if (target == null)
        {
            state = -1;
        }
    }

    private void Serving()
    {
        plating.food = state;
        plating.isPoison = isPoison;

        renderer.enabled = false;
        target = null;
    }
}