using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playBTN : MonoBehaviour
{
    public UnityEvent eventToClick;
    public UnityEvent eventToOver;
    public UnityEvent eventToExit;
    private void OnMouseDown()
    {
        eventToClick.Invoke();
    }
    private void OnMouseOver()
    {
        eventToOver.Invoke();
    }
    private void OnMouseExit()
    {
        eventToExit.Invoke();
    }
}
