///red attack strategy making it double damage when health is low and shooting fireballs when far away 

using System;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AttackStrategy/RedAttack")]
public class RedAttackStrategy : ScriptableObject, IAttackStrategy {

  [SerializeField] private int damageStrength = 10;

  [SerializeField] private GameObject fireballPrefab;
  [SerializeField] private float fireballSpeed;

  public void Attack(Health playerHealth, Health enemyHealth, EnemyMovement enemyMovement) {
    Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    Vector3 enemyPosition = enemyMovement.GetPosition();

    float distance = Vector3.Distance(enemyPosition, playerPosition);
    //Debug.Log("distance is: " + distance);

    if (enemyHealth.GetCurrentHealth() <= 25) {
      //Debug.Log("enemy health less than 25");
      playerHealth.GetHit(damageStrength * 2, "Regular");
    }
    else if (distance <= 5) {
      //Debug.Log("distance less than 10");
      playerHealth.GetHit(damageStrength, "Regular");
    }
    else if (distance > 5) {
      //Debug.Log("distance more than 10");
      GameObject fireballSpawnPoint = GameObject.FindGameObjectWithTag("FireballSpawnPoint");

      Transform camera = Camera.main.transform;
      Vector3 direction = (camera.position - fireballSpawnPoint.transform.position).normalized;

      GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, Quaternion.LookRotation(direction));

      Rigidbody rb = fireball.GetComponent<Rigidbody>();
      rb.linearVelocity = direction * fireballSpeed;
    }
    
    
  }
}
