using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Rigidbody myRb;
    public GameObject target;
    Vector3 targetPos;
    public float thrust;

	// Use this for initialization
	void Start (){
        myRb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	
    void FixedUpdate () {
        targetPos = target.transform.position;
        Vector3 direction = Vector3.Normalize(targetPos - transform.position);
        myRb.AddForce(direction * thrust);


        /// <summary>
        if (Input.GetKeyDown(KeyCode.W))
        {
           ///if true ... move the position of mover by (0,1,0)
            myRb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ///if true ... move the position of mover by (0,1,0)
            myRb.AddForce(-transform.forward * thrust);
        }
         if (Input.GetKeyDown(KeyCode.A))
        {
            ///if true ... move the position of mover by (0,1,0)
            myRb.AddForce(-transform.right * thrust);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ///if true ... move the position of mover by (0,1,0)
            myRb.AddForce(transform.right * thrust);
        }
        /// </summary>
    }
}
