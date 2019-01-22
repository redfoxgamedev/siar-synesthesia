using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamingCapability : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Oculus.Platform.Livestreaming.GetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
