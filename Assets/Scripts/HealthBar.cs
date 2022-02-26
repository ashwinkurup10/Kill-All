using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public Slider slider;
    public GameObject deathCam;
    public GameObject BloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        
        if (currentHealth == 0)
        {
            isDead();
        }
        


    }
    public void PlayerDamage(float damage)
    {
        currentHealth -= damage;
        BloodEffect.SetActive(true);
        Invoke("SetBloodeffect", 3);

    }
    public void isDead()
    { 
        deathCam.SetActive(true);

       
        Time.timeScale = 0f;
        Restart();
    }
    
    public void diecam()
    {
        deathCam.SetActive(false);
    }
    public void SetBloodeffect()
    {
        BloodEffect.SetActive(false);

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

}
