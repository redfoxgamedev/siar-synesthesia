using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTimer : MonoBehaviour {

    public Animation anim;

    void Start()
    {
        StartCoroutine(Example());

        anim = gameObject.GetComponent<Animation>();
      
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        print("Bloaw");
        anim.Play("dooropen");
    }
}
