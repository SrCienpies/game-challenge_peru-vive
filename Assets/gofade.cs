using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gofade : MonoBehaviour
{
    public Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void goanima()
    {
        StartCoroutine(startf());
    }

    IEnumerator startf()
    {
        anima.SetTrigger("go");
        yield return new WaitForSeconds(2.3f);
        this.gameObject.SetActive(false);
    }
}
