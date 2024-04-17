using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Statemanager statelink;
    public Button Startbutton;
    // Start is called before the first frame update
    void Start()
    {
        Startbutton.onClick.AddListener (startbutton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startbutton ()
    {
        statelink.currentstate = Statemanager.state.Play;
    }
}
