using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
    public Button quitbutton; 

    // Start is called before the first frame update
    void Start()
    {
        quitbutton.onClick.AddListener (QuitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitButton ()
    {
        Application.Quit ();
    }
}
