using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/** Source: Youtube by Natty Creations 
 * How to make a Better Health Bar in Unity : Chip Away Tutorial
 * https://www.youtube.com/watch?v=CFASjEuhyf4
 * Fully Operational but not assigned to player's vitals yet.  Added to Scene and Assets.Scipts folder
 * Note this is a place holder and the increase health bar Key "Z" and decrease health bar Key "X"
 * * Added to Comp391 Group Project by Jonathan Bonda 301288990 20230313
 * **/

public class PlayerHealth : MonoBehaviour
{

    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;


    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;


    }

    // Update is called once per frame
    void Update()
    {
        
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            // percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }        
        if(fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            // percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete);
        }
 
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

    public void IncreaseHealth(int level)
    {
        maxHealth += (health * 0.1f) * ((100 - level) * 0.1f);
        health = maxHealth;

    }
}
