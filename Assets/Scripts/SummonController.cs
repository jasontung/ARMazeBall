using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SummonController : MonoBehaviour {
    private TouchController touchController;
    public float summonTime = 5f;
    public SummomSetting[] summonSettings;
    private GameObject summonStuff;
    public Button nextButton;

    private void Awake()
    {
        touchController = GameObject.FindObjectOfType<TouchController>();
        touchController.onTouchCounterFinish += OnSummonOver;
        nextButton.gameObject.SetActive(false);
    }

    public void OnSummonStart ()
    {
        if (summonStuff)
            Destroy(summonStuff);
        nextButton.gameObject.SetActive(false);
        touchController.StartTouch(summonTime);
	}
	
    public void OnSummonLost()
    {
        touchController.Reset();
    }
    
	public void OnSummonOver(int power)
    {
        int usingIndex = 0;
        for(int i = 0; i < summonSettings.Length; i++)
        {
            if (power >= summonSettings[i].requirePower)
                usingIndex = i;
        }
        summonStuff = Instantiate(summonSettings[usingIndex].prefab);
        nextButton.gameObject.SetActive(true);
    }
}

[System.Serializable]
public class SummomSetting
{
    public GameObject prefab;
    public int requirePower;
}