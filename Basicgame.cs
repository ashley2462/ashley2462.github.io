﻿
using UnityEngine;
using System.Collections;

public class Basicgame : MonoBehaviour
{

    //make new public bool and GameObjects
    //remember that public means they can be edited in the Unity editor and by other scripts
    public bool goToWork;
    public GameObject mover; 
    public GameObject finishPos;
    public GameObject[] enemies;
    Vector3 moverOrigin; // we will use this to store the original position of mover
    Vector3 keyPos;
    bool hasKey;

    public Renderer rend;

    // Use this for initialization, similar to void setup() in Processing
    void Start()
    {
        moverOrigin = mover.transform.position; //store the original pos in moverOrigin
        keyPos = new Vector3(Random.Range(3, 0), 0, Random.Range(-4, -15));
        hasKey = false;
        //rend = GetComponent<Renderer>();
    }

    // Update is called once per frame, similar to void draw() in Processing
    void Update()
    {
        Debug.Log("game object is at ... " + mover.transform.position);
        Debug.Log("the key is at... " + keyPos);
        //check if the GetKeyDown function of Input returns true for "space" (the space bar)

            //check if the GetKeyDown function of Input returns true for "space" (the space bar)
            if (Input.GetKeyDown(KeyCode.W))
            {
                //if true ... move the position of mover by (0,1,0)
                mover.transform.position += new Vector3(0, 0, -1);
            }
            //check it the mover's position is equal to (0,5,0)
            if (mover.transform.position == new Vector3(0, 0, -1))
            {
                //if it is, add on this additional position (5,-5,0)
                mover.transform.position += new Vector3(0, 0, -1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //if true ... move the position of mover by (0,1,0)
                mover.transform.position += new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //if true ... move the position of mover by (0,1,0)
                mover.transform.position += new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //if true ... move the position of mover by (0,1,0)
                mover.transform.position += new Vector3(-1, 0, 0);
            }

            //check it the mover's position is less/greater than each border
            if ((mover.transform.position.z < -15)
                || (mover.transform.position.z > 0)
                || (mover.transform.position.x > 3)
                || (mover.transform.position.x < -4))
            {
                //if it is, reset to the original position (origin)
                mover.transform.position = moverOrigin;
            }


            //if the player is in the same position as the key, make hasKey true and play the (dog bark) sound
            if (mover.transform.position == keyPos)
        {
            hasKey = true;
        }

        if (hasKey)
        {
            //change the renderer's material color to red, indicating that the player can advance
            rend.material.color = Color.red;
        }

        //...if the player is in the finishing position
        if (mover.transform.position == finishPos.transform.position)
        {
            //and they "hasKey"
            if (hasKey)
            {

                //they win!
                Debug.Log("you win... yay :D");
            }
        }

        //we use a loop to cycle through each one of our enemies, no matter how many positions are in the array
        for (int i = 0; i < enemies.Length; i++)
        {
            //so long as the enemy is not past the rightmost position on the board (3), move them by 0.2 per frame
            if (enemies[i].transform.position.x < 3)
            {
                enemies[i].transform.position += new Vector3(.3f, 0,0);
            }
            else
            {
                enemies[i].transform.position = new Vector3(-4, enemies[i].transform.position.y, enemies[i].transform.position.z);
            }


            //if the player is in the same position as the enemy, reset them and the key
            if (mover.transform.position == enemies[i].transform.position)
            {
                mover.transform.position = moverOrigin;
                hasKey = false;
                keyPos = new Vector3(Random.Range(3, 0), 0, Random.Range(-4, -15));
            }

        }

    }
}
