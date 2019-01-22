using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTimer : MonoBehaviour {

    public Animator anim;

    void Start()
    {
        StartCoroutine(Example());

        anim = gameObject.GetComponent<Animator>();
      
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print("Bloaw");
        anim.Play("dooropen");
    }
}
