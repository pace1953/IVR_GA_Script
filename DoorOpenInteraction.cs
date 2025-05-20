using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DoorOpenInteraction : MonoBehaviour
{
    public string sceneName;
    public UnityEvent finishEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            SceneManager.LoadScene(sceneName);
            finishEvent.Invoke();
        }
    }
}
