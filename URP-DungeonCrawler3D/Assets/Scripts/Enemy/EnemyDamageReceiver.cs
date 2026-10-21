///if enemy collides with sword projectile, reduce health accordingly

using System.Transactions;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour {

  void Start() {
    
  }

  void Update() {

  }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("SwordProjectile")){
      Health enemyHealth = GetComponent<Health>();
      //does it make sense tho? no it does
      SwordProjectile swordProjectile = other.GetComponent<SwordProjectile>();
      enemyHealth.GetHit(swordProjectile.damageStrength, "Sword");
      //Debug.Log("EnemyHealth is now: " + enemyHealth.GetCurrentHealth());
    }
  }
}
