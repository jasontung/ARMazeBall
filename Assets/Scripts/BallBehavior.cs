using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    private Vector3 startPos;
    [ContextMenu("Reset Position")]
    private void ResetPosition()
    {
        transform.localPosition = startPos;
    }

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localPosition = startPos;
    }
}
