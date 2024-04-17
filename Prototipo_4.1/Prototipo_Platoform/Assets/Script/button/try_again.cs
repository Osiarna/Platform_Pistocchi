using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class try_again : MonoBehaviour
{
    public Statemanager statelink;
    public timer timerlink;
    public Button trybutton;
    // Start is called before the first frame update
    void Start()
    {
        trybutton.onClick.AddListener (tryagain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tryagain ()
    {
        statelink.currentstate = Statemanager.state.MainMenu;
    }
}
