using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynAudio : MonoBehaviour
{


    //adds gaze audio trigger by itself
    //if no audio source, adds it
    //adds specified audio to audio source

    public AudioClip clip;
    public Color colorToGlow;


    public Material currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = this.GetComponent<Renderer>().material;

        GameObject currentObject = this.gameObject;

        //add gaze audio trigger
        currentObject.AddComponent<GazeAudioTrigger>();

        if (currentObject.GetComponent<AudioSource>() == null){
            currentObject.AddComponent<AudioSource>();
        }

        //sets audio to audio source
        AudioSource audio = currentObject.GetComponent<AudioSource>();
        audio.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
