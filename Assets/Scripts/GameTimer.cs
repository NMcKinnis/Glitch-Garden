using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 60;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    private void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
         FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }

}
