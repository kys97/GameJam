using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public int state = -1;
    public bool isPoison = false;
    public GameObject target;
    private SpriteRenderer renderer;
    public List<int> Cost;
    //public Sprite[] sprites = new Sprite[18];

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
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                    SetBottle(state);

                    theAudio.clip = b1;
                    theAudio.Play();
                }
                else if (target.name == "B2")
                {
                    state = 3;
                    SetBottle(state);

                    theAudio.clip = b2;
                    theAudio.Play();
                }
                else if (target.name == "B3")
                {
                    state = 6;
                    SetBottle(state);

                    theAudio.clip = b3;
                    theAudio.Play();
                }

                if (state % 3 == 0)
                {
                    if (target.name == "C1")
                    {
                        state += 1;
                        //gamemanager.SetMoney(- Cost[3]);

                        theAudio.clip = milk;
                        theAudio.Play();
                    }
                    else if (target.name == "C2")
                    {
                        state += 2;
                        //gamemanager.SetMoney(- Cost[4]);

                        theAudio.clip = whiskey;
                        theAudio.Play();
                    }
                }

                if (state != -1 && isPoison == false && target.name == "Poison")
                {
                    isPoison = true;
                    state += 9;
                    //gamemanager.SetMoney(- Cost[5]);

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
            renderer.sprite = gamemanager.Bottles[state];
        }

        if (target == null)
        {
            state = -1;
        }
    }

    private void SetBottle(int bottle)
    {
        isPoison = false;
        renderer.enabled = true;
        //gamemanager.SetMoney(- Cost[bottle / 3]);
    }

    private void Serving()
    {
        plating.food = state;
        plating.isPoison = isPoison;

        renderer.enabled = false;
        target = null;
    }
}