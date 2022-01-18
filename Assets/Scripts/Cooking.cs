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

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
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
                string objectName = target.name;
            }
        }

        if (target != null)
        {
            if (target.name == "B1")
            {
                state = 0;
                isPoison = false;
                renderer.enabled = true;
            }
            else if (target.name == "B2")
            {
                state = 3;
                isPoison = false;
                renderer.enabled = true;
            }
            else if (target.name == "B3")
            {
                state = 6;
                isPoison = false;
                renderer.enabled = true;
            }
        }

        if (target != null && (state % 3 == 0))
        {
            if (target.name == "C1")
            {
                state += 1;
            }
            else if (target.name == "C2")
            {
                state += 2;
            }
        }

        if (state != -1 && isPoison == false && target.name == "Poison")
        {
            isPoison = true;
            state += 9;
        }

        if (state != -1)
        {
            renderer.sprite = sprites[state];
        }

        if (target != null)
        {
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

    private void Serving()
    {
        plating.food = state;
        plating.isPoison = isPoison;

        state = -1;
        renderer.enabled = false;
    }
}