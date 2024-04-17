using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class return_to_menu : MonoBehaviour
{
    public timer timerlink;
    public Statemanager statelink;
    public Button returnbutton;
    // Start is called before the first frame update
    void Start()
    {
        returnbutton.onClick.AddListener (retcon);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void retcon ()
    {
        statelink.currentstate = Statemanager.state.MainMenu;
    }
}
