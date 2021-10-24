using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeScore : MonoBehaviour
{
    Text text;
    public bool stop;
    ushort min,hours;
    ushort secons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countTimer());
        text = GetComponent<Text>();
    }
    IEnumerator countTimer(){
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(!stop){
                secons++;
                if(secons >= 60){
                    secons = 0;
                    min++;
                    if(min >= 60){
                        min = 0;
                        hours++;
                    }
                }
                text.text = $"{hours.ToString("00")}:{min.ToString("00")}:{secons.ToString("00")}";
            }
        }

    }
}
