using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestarLevelBTN : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(restart);
    }

    // Update is called once per frame
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
