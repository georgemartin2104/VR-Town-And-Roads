using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public Transform location;
    public Rigidbody rb;
    public int startLoc;
    public bool stopped = false;
    public bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        location = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        passed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
             Vector3 pos1 = new Vector3(-2.2f, 0f, -57f);
             Vector3 pos2 = new Vector3(2.2f, 0f, 57f);
             if (this.transform.position == pos1)
             {
                 startLoc = 1;
                 this.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
             }
             if (this.transform.position == pos2)
             {
                 startLoc = 2;
                 this.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
             }
            //calculate velocity for this frame
            Vector3 velocity = transform.position;
            velocity.Normalize();
            if (velocity.z < maxSpeed)
            {
                velocity.z = velocity.z + speed;
            }
            if (velocity.z >= maxSpeed)
            {
                velocity.z = maxSpeed;
            }
            //apply velocity
            Vector3 newPosition = transform.position;
            if (stopped)
            {
                velocity.z = 0;
            }
            if (startLoc == 1) newPosition += velocity * Time.deltaTime;
            if (startLoc == 2) newPosition -= velocity * Time.deltaTime;
            rb.MovePosition(newPosition);
            if (startLoc == 1)
            {
                if (this.transform.position.z >= 57)
                {
                    passed = false;
                    this.gameObject.SetActive(false);
                }
            }
            if (startLoc == 2)
            {
                if (this.transform.position.z <= -57)
                {
                    passed = false;
                    this.gameObject.SetActive(false);
                }
            }
        stopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("HasPassed"))
        {
            passed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("StopHitbox"))
        {
            if (!passed)
            {
                stopped = true;
            }
        }
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            if (!passed)
            {
                stopped = true;
            }
        }
        if (other.gameObject.CompareTag("CarHitbox"))
        {
            if (startLoc == 1 && other.gameObject.transform.position.z > this.gameObject.transform.position.z)
            {
                stopped = true;
            }
            if (startLoc == 2 && other.gameObject.transform.position.z < this.gameObject.transform.position.z)
            {
                stopped = true;
            }
        }
        if (other.gameObject.CompareTag("CrossHitbox"))
        {
            if (startLoc == 1 && this.gameObject.transform.position.z < 17)
            {
                stopped = true;
            }
            if (startLoc == 2 && this.gameObject.transform.position.z > 29)
            {
                stopped = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StopHitbox"))
        {
            stopped = false;
        }
        if (other.gameObject.CompareTag("CrossHitbox"))
        {
            stopped = false;
        }
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            stopped = false;
        }
        if (other.gameObject.CompareTag("CarHitbox"))
        {
            stopped = false;
        }
    }
}
