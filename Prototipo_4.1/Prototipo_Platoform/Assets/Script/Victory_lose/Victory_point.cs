using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Victory_point : MonoBehaviour
{
    public timer timerlink;
    public GameObject winUI;
    public Playermovement playerlink;
    public Statemanager statelink;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
           winUI.SetActive(true);
           timerlink.stoptime();
           playerlink.stopplayer();
        }
    }
}
