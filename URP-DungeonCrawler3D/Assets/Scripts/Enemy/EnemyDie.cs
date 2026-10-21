///enemy dies event observer pattern makes sure enemy plays death animation and is destroyed

using UnityEngine;

public class EnemyDie : MonoBehaviour
{
  public Health health;

  [SerializeField] private float destroyDelay = 1.5f;

  private void Start() {

  }

  private void OnEnable() {
    health.onDie += EnemyDead;
  }

  private void OnDisable() {
    health.onDie -= EnemyDead;
  }

  void EnemyDead() {
    GetComponent<EnemyAttack>().enabled = false;
    GetComponent<Animator>().CrossFade("Die", 0.05f, 0, 0f);
    Destroy(gameObject, destroyDelay);
  }
}
