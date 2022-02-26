using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject anyKey;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            anyKey.SetActive(false);
            Time.timeScale = 1f;

        }
        
    }
}
