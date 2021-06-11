using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    int i = 0;
    void Update()
    {
        if(PauseHandling.isPaused) { return; }
        
        Debug.Log("testing pause " + i++);
    }
}
