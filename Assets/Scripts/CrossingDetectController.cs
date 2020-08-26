using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingDetectController : MonoBehaviour
{
    public GameObject Lane1Stop;
    public GameObject Lane2Stop;

    // Start is called before the first frame update
    void Start()
    {
        Lane1Stop = GameObject.Find("Lane1Stop");
        Lane2Stop = GameObject.Find("Lane2Stop");
        Lane1Stop.SetActive(false);
        Lane2Stop.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
        {
            Lane1Stop.SetActive(true);
            Lane2Stop.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Pedestrian"))
        {
            Lane1Stop.SetActive(false);
            Lane2Stop.SetActive(false);
        }
    }
}
