using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiterFPS : MonoBehaviour
{
    
      
      public int target = 120;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
    void Update()
    {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
