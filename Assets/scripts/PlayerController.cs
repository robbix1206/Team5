﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector2 pos = new Vector2(0, 0);

    private Vector2 org;
    private bool keyUp = false;
    private bool keyLeft = false;
    private bool keyRight = false;
    private bool keyDown = false;


    protected int[][] tab = new int[52][] { 
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4,4},
    new int[19] {5,0,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4,4},
    new int[19] {5,0,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,5,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4},
    new int[19] {0,5,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4,4},
    new int[19] {0,0,5,0,0,0,0,0,0,0,2,2,2,2,2,4,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4,4},
    new int[19] {0,0,5,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,4,4,4},
    new int[19] {0,0,5,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4},
    new int[19] {0,0,0,5,0,0,0,0,0,0,2,2,2,2,2,2,4,4,5},
    new int[19] {0,0,5,5,5,0,0,0,0,0,2,2,2,2,2,2,4,4,5},
    new int[19] {0,0,5,0,0,0,0,0,0,0,2,2,2,2,2,2,4,5,4},
    new int[19] {0,0,0,0,5,0,0,0,0,0,2,2,2,2,2,2,4,4,4},
    new int[19] {0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,5,4},
    new int[19] {1,0,0,0,5,0,0,0,0,0,2,2,2,2,2,2,4,5,4},
    new int[19] {1,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,5,4,4},
    new int[19] {1,0,0,0,5,0,0,0,0,0,2,2,2,2,2,2,5,4,4},
    new int[19] {1,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,4,4,4},
    new int[19] {1,1,0,0,5,0,0,0,0,0,0,2,2,2,2,2,5,4,4},
    new int[19] {1,0,0,0,0,0,0,0,0,0,2,2,2,2,2,5,4,4,4},
    new int[19] {1,1,0,0,5,0,0,0,0,0,0,2,2,2,2,5,2,4,4},
    new int[19] {1,1,0,0,0,0,0,0,0,0,2,2,2,2,5,2,4,4,4},
    new int[19] {1,1,0,0,5,0,0,0,0,0,0,2,2,2,5,2,2,4,4},
    new int[19] {1,1,0,0,5,0,0,0,0,0,2,2,2,2,2,2,2,4,4},
    new int[19] {1,1,0,0,0,5,0,0,0,0,0,2,2,5,5,2,2,2,4},
    new int[19] {1,1,0,0,0,5,5,5,5,0,2,2,5,5,2,2,2,2,4},
    new int[19] {1,1,1,0,0,0,5,5,5,5,0,2,5,2,2,2,2,2,2},
    new int[19] {1,1,0,0,0,0,0,0,0,5,5,2,2,2,2,2,2,2,4},
    new int[19] {1,1,1,0,0,0,0,0,0,0,5,5,5,2,2,2,2,2,2},
    new int[19] {1,1,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,4},
    new int[19] {1,1,1,0,1,0,0,0,0,0,0,0,2,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2,2,4},
    new int[19] {1,1,1,1,1,1,0,0,0,0,0,0,2,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,0,0,0,0,0,0,2,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,0,0,0,0,0,0,2,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,2,2,2,2},
    new int[19] {1,1,1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2},
    new int[19] {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,2,2,2,2},
    new int[19] {1,1,1,1,1,1,1,0,0,0,0,0,0,0,2,2,2,2,2}
    };
    // Use this for initialization
    void Start () {
        org = transform.position;
    }
	
    void displayCase()
    {
        switch (tab[(int) this.pos.y][(int) this.pos.x])
        {
            case 0:
                print("Sand");
                break;
            case 1:
                print("Water");
                break;
            case 2:
                print("Grass");
                break;
            case 3:
                print("Nothing");
                break;
            case 4:
                print("Castle");
                break;
            case 5:
                print("Path");
                break;
            default:
                print("Unknown");
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            if (!keyRight)
            {
                keyRight = true;
                if (pos.y % 2 == 0)
                {
                    if (pos.y + 1 < 51)
                    {
                        pos.y += 1;
                        transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y - 0.5f);
                        displayCase();
                    }
                }
                else
                {
                    if (pos.y - 1 >= 0 && pos.x + 1 < 19)
                    {
                        pos.y -= 1;
                        pos.x += 1;
                        transform.position = new Vector2(transform.position.x + 1.35f, transform.position.y + 0.5f);
                        displayCase();
                    }
                }
            }
        }
        else
        {
            keyRight = false;
        }
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            if (!keyLeft)
            {
                keyLeft = true;
                if (pos.y % 2 == 1)
                {
                    if (pos.y - 1 >= 0)
                    {
                        pos.y -= 1;
                        transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y + 0.5f);
                        displayCase();
                    }
                }
                else
                {
                    if (pos.y + 1 < 51 && pos.x - 1 >= 0.0f)
                    {
                        pos.y += 1;
                        pos.x -= 1;
                        transform.position = new Vector2(transform.position.x - 1.35f, transform.position.y - 0.5f);
                        displayCase();
                    }
                }
            }
        }
        else
        {
            keyLeft = false;
        }
        if (Input.GetAxis("Vertical") >= 0.1f)
        {
            if (!keyUp)
            {
                keyUp = true;
                if (pos.y - 2 >= 0)
                {
                    pos.y -= 2;
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1.0f);
                    displayCase();
                }
            }
        }
        else
        {
            keyUp = false;
        }
        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            if (!keyDown)
            {
                keyDown = true;
                if (pos.y + 2 < 51)
                {
                    pos.y += 2;
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1.0f);
                    displayCase();
                }
            }
        }
        else
        {
            keyDown = false;
        }
    }
}