using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent finishEvent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishEvent.Invoke();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            finishEvent.Invoke();
        }
    }
}