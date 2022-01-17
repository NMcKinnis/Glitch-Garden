using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    private void Start()
    {
        if (winLabel)
        {
            winLabel.SetActive(false);
        }
        if (loseLabel)
        {
            loseLabel.SetActive(false);
        }
        else return;
  
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if  (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        var audioSource = GetComponent<AudioSource>();
        if (audioSource == null) { yield break; }
            audioSource.Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
 public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
 
}
