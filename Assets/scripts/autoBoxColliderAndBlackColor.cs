using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class autoBoxColliderAndBlackColor : MonoBehaviour
{
    [Range(0,1)]
    public float Thickness = 0.99f;
    SpriteRenderer sr;
    SpriteRenderer srChild;
    private void OnDrawGizmosSelected()
    {
        if(sr == null){
            sr = GetComponent<SpriteRenderer>();
            
        }
        if(srChild == null){
            if(GetComponentsInChildren<SpriteRenderer>().Length > 1){
               srChild = GetComponentsInChildren<SpriteRenderer>()[1];
            } 
        }
        if(GetComponent<BoxCollider2D>() != null){
            GetComponent<BoxCollider2D>().size = sr.size;
        }
        if(srChild != null){
            srChild.transform.localPosition = Vector3.zero;
            srChild.size = sr.size - (Vector2.one * Thickness);
            srChild.transform.localScale = sr.transform.localScale;
            srChild.sortingOrder = sr.sortingOrder + 1; 
        }

        if(GetComponent<ParticleSystem>() != null) {
            var sh = GetComponent<ParticleSystem>().shape;
            sh.scale = (Vector3)sr.size;
        } 
        
    }

}
