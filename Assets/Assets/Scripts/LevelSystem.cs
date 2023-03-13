using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/** Source: Youtube by Natty Creations 
 * Level Up! How to make a Scalable Level System: Unity Tutorial
 * https://www.youtube.com/watch?v=H3L0JRtqWP8 and all done until 14min of video
 * Have not added the GainexExperienceScalable Method yet but 
 * the "=" Equals key will increase the xp bars 
 * Added to Scene and Assets.Scipts folder
 * Added to Comp391 Group Project by Jonathan Bonda 301288990 20230313
 * **/

public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXP;
    public float requiredXP;

    private float lerpTimer;
    private float delayTimer;
    
    [Header("UI")]
    public Image frontXPBar;
    public Image backXPBar;
    
    [Header("Multiplier")]
    [Range(1f, 300f)]
    public float additionalMultiplier = 300;
    [Range(2f, 4f)]
    public float powerMultiplier = 2;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7;


    // Start is called before the first frame update
    void Start()
    {
        frontXPBar.fillAmount = currentXP / requiredXP;
        backXPBar.fillAmount = currentXP / requiredXP;
        requiredXP = CalculateRequiredXP();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.Equals)) // NumPad + "PLUS" key
            GainExperienceFlatRate(20);

        if (currentXP > requiredXP)
            LevelUp();


    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXP / requiredXP;
        float XFP = frontXPBar.fillAmount;
        if(XFP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXPBar.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXPBar.fillAmount = Mathf.Lerp(XFP, backXPBar.fillAmount, requiredXP);
            }
        }
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXP += xpGained;
        lerpTimer = 0f;
    }

    /**
    public void GainedExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXP += xpGained * multiplier;
        }
        else
        {
            currentXP += xpGained;
        }
        lerpTimer = 0f;
        delayTimer = 0f;

    } **/


    public void LevelUp()
    {
        level++;
        frontXPBar.fillAmount = 0f;
        backXPBar.fillAmount = 0f;
        currentXP = Mathf.RoundToInt(currentXP - requiredXP);
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        requiredXP = CalculateRequiredXP();
    }

    private int CalculateRequiredXP()
    {
        int solveForRequiredXP = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXP += (int)Mathf.Floor(levelCycle + additionalMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXP / 4;

    }


}
