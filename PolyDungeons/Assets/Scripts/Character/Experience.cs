using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Experience : MonoBehaviour
{
    public Image expImg;
    public Text levelText;
    public int currentLevel;

    [HideInInspector]
    public float currentExp;
    public float expToNextLevel;

    public static Experience instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        expImg.fillAmount = currentExp / expToNextLevel;
        currentLevel = 1;
        levelText.text=currentLevel.ToString();
    }

    
    void Update()
    {
        expImg.fillAmount = currentExp / expToNextLevel;
    }

    public void expMod(float experience)
    {
        currentExp += experience;
        expImg.fillAmount=currentExp/ expToNextLevel;
        if (currentExp >= expToNextLevel) 
        {
            expToNextLevel *= 2;
            currentExp = 0;
            currentLevel++;
            levelText.text = currentLevel.ToString();
        }
    }
}
