using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_script : MonoBehaviour
{

    public Transform jugador = null;
    Transform offset;
    public float vel_update = 1;
    public Vector3 anim_off_set;
    public Vector3 off_set;

    // Start is called before the first frame update
    void Start()
    {
        if(jugador == null)
        {
            jugador = GameObject.FindObjectOfType<PlayerMove>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(jugador.position.x, jugador.position.y, jugador.position.z) + off_set;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * vel_update);

    }
}
