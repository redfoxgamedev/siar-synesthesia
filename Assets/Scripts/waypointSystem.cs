using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointSystem : MonoBehaviour
{

    private GameObject waypoint;
    private GameObject target;
    private GameObject text1;
    private GameObject text2;
    // Start is called before the first frame update

    void Start()
    {
        waypoint = GameObject.Find("waypoint");
        waypoint.gameObject.SetActive(true);

        target = GameObject.Find("target");
        target.gameObject.SetActive(false);

        text2 = GameObject.Find("text2");
        text2.gameObject.SetActive(false);

        text1 = GameObject.Find("text1");
        text1.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waypoint.gameObject.SetActive(false);
            target.gameObject.SetActive(true);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waypoint.gameObject.SetActive(true);
            target.gameObject.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
