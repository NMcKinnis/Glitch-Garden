using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0.8f;
    [SerializeField] public DifficultyConfig[] difficulties;
    [SerializeField] public DifficultyConfig currentDifficulty;
    public static OptionsController currentInstance;


    private void Awake()
    {
        currentInstance = this;
        DontDestroyOnLoad(this);
   
    }
    private void Start()
    {

        if(difficultySlider && volumeSlider)
        {
            GetSliderValues();
        }
    }

    private void Update()
    {
        
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer && volumeSlider)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else if (musicPlayer && !volumeSlider)
        {
            musicPlayer.SetVolume(defaultVolume);
        }
        else
        {
            Debug.LogWarning("No music player found.... Did you start from splash screen?");
        }
    }
    public void SaveAndExit()
    {

        if (difficultySlider.value == 1)
        {
            currentInstance.currentDifficulty = difficulties[1];
        }
        else if (difficultySlider.value == 2)
        {
            currentInstance.currentDifficulty = difficulties[2];
        }
        else 
        {
            currentInstance.currentDifficulty = difficulties[0];
        }
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
    public void GetSliderValues()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }
}
