using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitBTN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(quit);
    }

    // Update is called once per frame
    void quit()
    {
        Application.Quit();
    }
}
