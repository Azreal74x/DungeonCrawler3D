///blue attack strategy making player take regular damage

using UnityEngine;

[CreateAssetMenu(menuName = "AttackStrategy/BlueAttack")]
public class BlueAttackStrategy : ScriptableObject, IAttackStrategy {
  [SerializeField] private int damageStrength = 10;
  public void Attack(Health playerHealth, Health enemyHealth, EnemyMovement enemyMovement) {
    playerHealth.GetHit(damageStrength, "Regular");
  }

}
