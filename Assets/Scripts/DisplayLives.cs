using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLives: MonoBehaviour
{
    
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;
    public float Lives => OptionsController.currentInstance.currentDifficulty.maxHealth;
    void Start()
    {
        lives = Lives;
        livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Difficulty setting is currently " + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }
    public void TakeLife ()
    {
       lives -= damage;
       UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
