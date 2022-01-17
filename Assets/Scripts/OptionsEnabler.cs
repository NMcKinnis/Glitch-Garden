using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class OptionsEnabler : MonoBehaviour
{
    [SerializeField] OptionsController defaultOptionsController;
    private void Awake()
    {
        var optionsEnabler = FindObjectsOfType<OptionsController>().Length;
        if (optionsEnabler <1)
        {
            Instantiate(defaultOptionsController, transform.position, transform.rotation);
        }
    }
}