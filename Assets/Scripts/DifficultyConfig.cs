using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DifficultyConfig")]
public class DifficultyConfig : ScriptableObject
{
    [SerializeField] private float _minSpawnTime;
    public float minSpawnTime { get => _minSpawnTime; private set => _minSpawnTime = value; } 
    [SerializeField] private float _maxSpawnTime;
    public float maxSpawnTime { get => _maxSpawnTime; private set => _maxSpawnTime = value; }
    [SerializeField] private float _maxHealth;
    public float maxHealth { get => _maxHealth; private set => _maxHealth = value; }



}

