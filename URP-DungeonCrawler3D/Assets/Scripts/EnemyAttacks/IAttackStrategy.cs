///interface for different enemy attack strategies  

using UnityEngine;

public interface IAttackStrategy {
  void Attack(Health playerHealth, Health enemyHealth, EnemyMovement enemyMovement);

}
