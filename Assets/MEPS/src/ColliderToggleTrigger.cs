using System;
using UnityEngine;

public class ColliderToggleTrigger : MonoBehaviour
{
    public event Action OnEnter;
    public event Action OnExit;
    
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            OnEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Ball"){
            OnExit?.Invoke();
        }
    }
}
