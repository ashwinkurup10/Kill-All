using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth singleton;
    public HealthBar playHealth;
    
    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target")
        {
            playHealth.PlayerDamage(5f);
        }
    }

}
