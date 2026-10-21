///fireball projectile that damages the player on contact and destroys after traveling a certain distance

using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
  [SerializeField] public int damageStrength = 10;
  private float maxDistance = 20f;
  private Vector3 startPos;

  private void Start() {
    startPos = transform.position;
  }

  private void Update() {
    if (Vector3.Distance(startPos, transform.position) >= maxDistance) {
      Destroy(gameObject);
    }
  }

  private void OnTriggerEnter(Collider other) {
    if (other != null) {
      if (other.gameObject.CompareTag("Player")) {
        Health playerHealth = other.gameObject.GetComponent<Health>();
        playerHealth.GetHit(damageStrength, "Fireball");
      }
    }
  }
}
