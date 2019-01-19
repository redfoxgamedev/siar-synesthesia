using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTest : MonoBehaviour
{
    public Renderer renderer;
    public AudioSource audio;
    private Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        audio = this.GetComponent<AudioSource>();
        initialColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGazeEnter(){
        renderer.material.color = Color.yellow;
        audio.Stop();
        audio.Play();
    }

    public void onGazeExit(){
        renderer.material.color = initialColor;
    }
}
