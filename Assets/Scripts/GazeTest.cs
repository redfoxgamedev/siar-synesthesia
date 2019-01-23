using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTest : MonoBehaviour
{
    public Renderer renderer;
    private Color initialColor;

    public Renderer[] childRenderers;
    private Color[] initialColors;

    public AudioSource itemAudio;

    public bool dependsOnChildren;


    // Start is called before the first frame update
    void Start()
    {
        //if this is the only renderer (simple object)

        //renderer = this.GetComponent<Renderer>();

        if (!(this.GetComponent<Renderer>()))
        {
            childRenderers = this.GetComponentsInChildren<Renderer>();
            initialColors = getInitialColorsFrom(childRenderers);
            dependsOnChildren = true;
        }
        else
        {
            renderer = this.GetComponent<Renderer>();
            initialColor = renderer.material.color;
            dependsOnChildren = false;
        }

        itemAudio = this.GetComponent<AudioSource>();

    }

    private Color[] getInitialColorsFrom(Renderer[] renderers)
    {
        int size = renderers.Length;
        Color[] result = new Color[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = renderers[i].material.color;
        }

        return result;
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void onGazeEnter()
    {
        Color colorForGaze = Color.yellow;
        if (!dependsOnChildren)
        {
            Material[] materials = renderer.materials;
            setAllMaterialsColorTo(materials, colorForGaze);
            //renderer.material.color = colorForGaze;
        }
        else
        {
            toggleMultipleColorsTo(Color.yellow);
        }

        itemAudio.Stop();
        itemAudio.Play();
    }

    public void onGazeExit()
    {
        if (!dependsOnChildren)
        {
            Material[] materials = renderer.materials;
            setAllMaterialsColorTo(materials, initialColor);
            //renderer.material.color = initialColor;
        }
        else
        {
            toggleMultipleColorsBack();
        }
    }

    private void toggleMultipleColorsTo(Color someColor)
    {
        int size = childRenderers.Length;
        for (int i = 0; i < size; i++)
        {
            //make sure to work with multiple materials;

            Material[] materials = childRenderers[i].materials;

            setAllMaterialsColorTo(materials, someColor);

            //childRenderers[i].material.color = someColor;
        }
    }

    private void toggleMultipleColorsBack()
    {
        int size = childRenderers.Length;
        for (int i = 0; i < size; i++)
        {
            Material[] materials = childRenderers[i].materials;
            setAllMaterialsColorTo(materials, initialColors[i]);

            //childRenderers[i].material.color = initialColors[i];
        }
    }

    private void setAllMaterialsColorTo(Material[] materials, Color someColor)
    {
        int size = materials.Length;

        for (int i = 0; i < size; i++){
            materials[i].color = someColor;
        }
    }

   
}
