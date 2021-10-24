using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class camaraPlayerView : MonoBehaviour
{   
    public Camera _Cam;
    public BoxCollider2D boxCollider2D;
    private void OnDrawGizmos()
    {
        if(boxCollider2D == null){
            if(GetComponent<BoxCollider2D>() == null){
                boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
            }else{
                boxCollider2D = GetComponent<BoxCollider2D>();

            }
        }
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(transform.position + (Vector3)boxCollider2D.offset ,  boxCollider2D.size * 0.99f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position ,  Vector3.one * 1);
    }
    private void Start()
    {
        _Cam = Camera.main;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            _Cam.transform.position = this.transform.position;
        }
    }

    
}
