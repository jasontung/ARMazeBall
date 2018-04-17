using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class TouchController : MonoBehaviour
{
    public int touchCount = 0;
    public event Action<int> onTouchCounterFinish;
    public Transform touchEffectsRoot;
    public Slider timeBar;
    private ParticleSystem[] allTouchEffects;
    private void Awake()
    {
        allTouchEffects = new ParticleSystem[touchEffectsRoot.childCount];
        foreach(Transform child in touchEffectsRoot)
        {
            allTouchEffects[child.GetSiblingIndex()] = child.GetComponent<ParticleSystem>();
        }
        Reset();
    }

    public void Reset()
    {
        timeBar.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void StartTouch(float duration)
    {
        touchCount = 0;
        StartCoroutine(DoTouchCounter(duration));
    }

    IEnumerator DoTouchCounter(float duration)
    {
        timeBar.gameObject.SetActive(true);
        timeBar.maxValue = duration;
        timeBar.value = timeBar.maxValue;
        while (duration > 0)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                touchCount++;
                PlayTouchEffect();
            }
#else
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    touchCount++;
                    PlayTouchEffect();
                }
            }
#endif
            yield return null;
            duration -= Time.deltaTime;
            timeBar.value = duration;
        }
        if (onTouchCounterFinish != null)
            onTouchCounterFinish.Invoke(touchCount);
    }

    private void PlayTouchEffect()
    {
        int index = UnityEngine.Random.Range(0, allTouchEffects.Length);
        allTouchEffects[index].Play();
    }
}
