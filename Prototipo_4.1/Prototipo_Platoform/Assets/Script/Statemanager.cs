using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour

{
    public Victory_point Victorylink;
    public Playermovement playerlink;
    public timer timerlink;
    public state currentstate;
    public state previoustate;
    // Start is called before the first frame update
    void Start()
    {
        currentstate = state.MainMenu;
        previoustate = state.MainMenu;        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentstate)
        {
            case state.Play:
                break;
            case state.Death:
                break;
            case state.MainMenu:
                break;
            case state.Win:
                break;
        }
        if (currentstate != previoustate)
        {
            switch (currentstate)
            {
                case state.Play:
                    timerlink.starttime();
                    playerlink.playersetup();
                    playerlink.startplayer();
                    break;
                case state.Death:
                    timerlink.stoptime();
                    playerlink.stopplayer();
                    break;
                case state.MainMenu:
                    timerlink.resettime();
                    timerlink.stoptime();
                    playerlink.stopplayer();
                    break;
                case state.Win:
                    timerlink.stoptime();
                    playerlink.stopplayer();
                    break;
                

            }
        previoustate = currentstate;
        }

    }

    public enum state
    {
        MainMenu,
        Play,
        Pause,
        Win,
        Death
    }
    private state ChangeState(state newstate)
    {
        currentstate = newstate;
        return newstate;
    }
} 
