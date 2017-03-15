using UnityEngine;
using System.Collections;

public class BasicConditionals : MonoBehaviour
{

    //make new public bool and GameObjects
    //remember that public means they can be edited in the Unity editor and by other scripts
    public bool goToWork;
    public GameObject mover;
    Vector3 moverOrigin; // we will use this to store the original position of mover

    // Use this for initialization, similar to void setup() in Processing
    void Start()
    {
        moverOrigin = mover.transform.position; //store the original pos in moverOrigin
    }

    // Update is called once per frame, similar to void draw() in Processing
    void Update()
    {
        Debug.Log("game object is at ... " + mover.transform.position);

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

    }
}