using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;

    IEnumerator Start()
    {
      while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
            SpawnAttacker();
        }
    }
    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        if (spawn)
        {
            var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
            Spawn(attackerPrefabArray[attackerIndex]);
        }
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
                    (myAttacker, transform.position, transform.rotation)
                    as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
