using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Slider hpBar;

    int maxHealth;

    void Start()
    {
        maxHealth = (int)health;
        hpBar.value = health;
    }

    void Update()
    {
        
    }

    public void ChangeHealth(int healthDelta)
    {
        health += healthDelta;
        if(health > maxHealth)
        {
            health= maxHealth;
        }

        if(health < 0)
        {
            health= 0;
            GameOver();
        }

        hpBar.value = health;
    }

    void GameOver()
    {
        SceneManager.LoadScene("FinalSceneAndrei");
    }
}
