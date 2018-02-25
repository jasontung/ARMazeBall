using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class UnityEventARBehavior : DefaultTrackableEventHandler {
    public UnityEvent onTrackingFound;
    public UnityEvent onTrackingLost;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        onTrackingFound.Invoke();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        onTrackingLost.Invoke();
    }
}
