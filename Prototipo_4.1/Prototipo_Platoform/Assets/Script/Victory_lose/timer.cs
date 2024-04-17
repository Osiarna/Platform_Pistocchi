using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float TimeValue = 90F;
    public float maxtimer = 90F;
    public Text timer_over;
    public GameObject LooseUI;
    public Victory_point victorylink;
    public Statemanager statelink;
    public GameObject MainMenuUI;
    bool paused;

    public Playermovement playerlink;
    // Start is called before the first frame update
    void Awake()
    {
        paused = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(TimeValue > 0 && !paused) 
        {
            TimeValue -= Time.deltaTime;
        }
        else
        {
            if (TimeValue < 0)
            {
                TimeValue = 0;
            }
        }
        timer_over.text = "Time: " + Mathf.Round (TimeValue);

        if(TimeValue == 0)
        {
            LooseUI.SetActive(true);
            playerlink.stopplayer();
        }
    }
    public void stoptime()
    {
        paused = true;
    }
    public void starttime()
    {
        paused = false;
    }
    public void resettime()
    {
        TimeValue = maxtimer;
    }
}
