///enemy attacks the player when in range and uses strategy pattern for different attack types

using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
  [SerializeField] GameObject player;
  Health playerHealth;
  [SerializeField] Health enemyHealth;
  [SerializeField] EnemyMovement enemyMovement;

  [SerializeField] float attackRange = 5f;
  [SerializeField] int damageStrength = 10;

  [SerializeField] private Animator animator;
  //private string[] animations = { "idle01", "idle02", "Walk", "getHit", "die", "Basic Attack", "Claw Attack" };

  [SerializeField] private float attackCooldown = 5f;
  private bool canAttack = true;

  [SerializeField] private ScriptableObject attackStrategyObject;
  private IAttackStrategy attackStrategy;

  private void Awake() {
    attackStrategy = attackStrategyObject as IAttackStrategy;
  }

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    playerHealth = player.GetComponent<Health>();
    enemyHealth = GetComponent<Health>();
    enemyMovement = GetComponent<EnemyMovement>();
  }

  private void Update() {
    CheckAttack();
  }

  private void CheckAttack() {
    float distance = Vector3.Distance(transform.position, player.transform.position);

    if (canAttack && distance < attackRange) {
      canAttack = false;
      StartCoroutine(Attack());
    }
  }

  private IEnumerator Attack() {
    attackStrategy.Attack(playerHealth, enemyHealth, enemyMovement);
    animator.SetTrigger("Basic Attack");

    yield return new WaitForSeconds(attackCooldown);

    canAttack = true;
  }

}

//future animation ideas
//idle01-idle02
//player in range -> Walk
//player in attack range -> Basic Attack
//player attacks back -> getHit
//die -> die

