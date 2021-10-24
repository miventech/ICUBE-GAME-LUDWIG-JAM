using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject lazer;
    public float delay;
    public float timeOn;
    public float timeOff;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cycle());
    }
    IEnumerator cycle(){
        yield return new WaitForSeconds(delay);
        while (true)
        {
            lazer.SetActive(true);
            yield return new WaitForSeconds(timeOn);
            lazer.SetActive(false);
            yield return new WaitForSeconds(timeOff);
            
        }
        
    }
}
