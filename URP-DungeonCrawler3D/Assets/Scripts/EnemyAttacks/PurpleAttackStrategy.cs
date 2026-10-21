///purple attack strategy to make enemy shoot fireballs at player

using UnityEngine;

[CreateAssetMenu(menuName = "AttackStrategy/PurpleAttack")]
public class PurpleAttackStrategy : ScriptableObject, IAttackStrategy {
  [SerializeField] private GameObject fireballPrefab;
  [SerializeField] private float fireballSpeed;

  public void Attack(Health playerHealth, Health enemyHealth, EnemyMovement enemyMovement) {
    //GameObject fireballSpawnPoint = GameObject.FindGameObjectWithTag("FireballSpawnPoint");
    Transform fireballSpawnPoint = enemyMovement.transform.Find("FireballSpawnPoint");

    Transform camera = Camera.main.transform;
    Vector3 direction = (camera.position - fireballSpawnPoint.transform.position).normalized;

    // Spawn the fireball at the enemy’s position
    GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, Quaternion.LookRotation(direction));

    // Give fireball velocity
    Rigidbody rb = fireball.GetComponent<Rigidbody>();
    rb.linearVelocity = direction * fireballSpeed;
  }
}
