///spawns enemies at regular intervals

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

  [SerializeField] private GameObject enemy;
  [SerializeField] public float cooldown;
  private bool canSpawn = true;

  private void Start() {
    
  }

  private void Update() {
    if (canSpawn) {
      StartCoroutine(spawnEnemy());
    }
  }

  private IEnumerator spawnEnemy() {
    canSpawn = false;
    GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
    //Debug.Log("Spawned a new enemy");
    yield return new WaitForSeconds(cooldown);
    canSpawn = true;
  }
}
