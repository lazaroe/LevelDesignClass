using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerWIthPLayerEvent : MonoBehaviour
{
    public UnityEvent EnterEvent, ExitEvent, StayEvent;
    public string tagtocompare = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagtocompare))
        {
            EnterEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tagtocompare))
        {
            StayEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagtocompare))
        {
            ExitEvent.Invoke();
        }
    }
}
