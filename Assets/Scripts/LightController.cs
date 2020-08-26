using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject TL1;
    public GameObject TL1Red;
    public GameObject TL1Green;
    public GameObject TL2;
    public GameObject TL2Red;
    public GameObject TL2Green;
    public GameObject TL2Collider;
    public GameObject TL3;
    public GameObject TL3Red;
    public GameObject TL3Green;
    public GameObject TL3Collider;
    public GameObject Lane2Stop;
    public int state = 1;
    public float timer = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the gameobjects for the light frames and lights automatically (rather than drag and dropping them through the editor)
        TL1 = GameObject.Find("TL1");
        TL1.AddComponent<Transform>();
        TL1Red = GameObject.Find("TL1/Red light");
        TL1Green = GameObject.Find("TL1/Green light");
        TL2 = GameObject.Find("TL2");
        TL2Red = GameObject.Find("TL2/Red light");
        TL2Green = GameObject.Find("TL2/Green light");
        TL2Collider = GameObject.Find("TL2/TL2Collider");
        TL3 = GameObject.Find("TL3");
        TL3Red = GameObject.Find("TL3/Red light");
        TL3Green = GameObject.Find("TL3/Green light");
        TL3Collider = GameObject.Find("TL3/TL3Collider");
        Lane2Stop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease timer each second, when reaches 0 change state and run lightcontrols()
        timer -= Time.deltaTime;
        if (state == 1)
        {
            Lane2Stop.SetActive(true);
        }
        if (timer <= 0.0f)
        {
            
            if(state == 1)
            {
                state = 2;
            }
            else if(state == 2)
            {
                state = 1;
            }
            LightControls();
            timer = 20.0f;
        }
    }

    //Change the state of the lights when function activates
    void LightControls()
    {
        if (state == 1)
        {
            TL1Red.SetActive(false);
            TL1Green.SetActive(true);
            TL2Red.SetActive(true);
            TL2Green.SetActive(false);
            TL2Collider.SetActive(true);
            TL3Red.SetActive(true);
            TL3Green.SetActive(false);
            TL3Collider.SetActive(true);
            Lane2Stop.SetActive(true);
        }
        if (state == 2)
        {
            TL1Red.SetActive(true);
            TL1Green.SetActive(false);
            TL2Red.SetActive(false);
            TL2Green.SetActive(true);
            TL2Collider.SetActive(false);
            TL3Red.SetActive(false);
            TL3Green.SetActive(true);
            TL3Collider.SetActive(false);
            Lane2Stop.SetActive(false);
        }
    }
}
