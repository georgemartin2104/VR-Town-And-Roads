using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerController : MonoBehaviour
{ 
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car4;
    public int startLoc = 1;
    public bool lane1Active = false;
    public bool lane2Active = false;
    public float laneDelay;
    public float lane1Reset;
    public float lane2Reset;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Car1 = GameObject.Find("Car1");
        Car2 = GameObject.Find("Car2");
        Car3 = GameObject.Find("Car3");
        Car4 = GameObject.Find("Car4");
        Car1.SetActive(false);
        Car2.SetActive(false);
        Car3.SetActive(false);
        Car4.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        int tmp = 0;
        tmp = Random.Range(1, 3);
        startLoc = tmp;
        float temp = 0f;
        temp = Random.Range(2, 10);
        laneDelay = temp;
        currentTime += Time.deltaTime;

        if (lane1Reset < currentTime)
        {
            lane1Active = false;
        }
        if (lane2Reset < currentTime)
        {
            lane2Active = false;
        }

        if (!Car1.activeSelf)
        {
            if (startLoc == 1 && lane1Active == false)
            {
                Car1.transform.position = new Vector3(-2.2f, 0f, -57f);
                Car1.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                lane1Active = true;
                lane1Reset = currentTime + laneDelay;
                Car1.SetActive(true);
            }
            if (startLoc == 2 && lane2Active == false)
            {
                Car1.transform.position = new Vector3(2.2f, 0f, 57f);
                Car1.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                lane2Active = true;
                lane2Reset = currentTime + laneDelay;
                Car1.SetActive(true);
            }
        }


        if (!Car2.activeSelf)
        {
            if (startLoc == 1 && lane1Active == false)
            {
                Car2.transform.position = new Vector3(-2.2f, 0f, -57f);
                Car2.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                lane1Active = true;
                lane1Reset = currentTime + laneDelay;
                Car2.SetActive(true);
            }
            if (startLoc == 2 && lane2Active == false)
            {
                Car2.transform.position = new Vector3(2.2f, 0f, 57f);
                Car2.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                lane2Active = true;
                lane2Reset = currentTime + laneDelay;
                Car2.SetActive(true);
            }
        }

        if (!Car3.activeSelf)
        {
            if (startLoc == 1 && lane1Active == false)
            {
                Car3.transform.position = new Vector3(-2.2f, 0f, -57f);
                Car3.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                lane1Active = true;
                lane1Reset = currentTime + laneDelay;
                Car3.SetActive(true);
            }
            if (startLoc == 2 && lane2Active == false)
            {
                Car3.transform.position = new Vector3(2.2f, 0f, 57f);
                Car3.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                lane2Active = true;
                lane2Reset = currentTime + laneDelay;
                Car3.SetActive(true);
            }
        }

        if (!Car4.activeSelf)
        {
            if (startLoc == 1 && lane1Active == false)
            {
                Car4.transform.position = new Vector3(-2.2f, 0f, -57f);
                Car4.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                lane1Active = true;
                lane1Reset = currentTime + laneDelay;
                Car4.SetActive(true);
            }
            if (startLoc == 2 && lane2Active == false)
            {
                Car4.transform.position = new Vector3(2.2f, 0f, 57f);
                Car4.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                lane2Active = true;
                lane2Reset = currentTime + laneDelay;
                Car4.SetActive(true);
            }
        }

    }


}
