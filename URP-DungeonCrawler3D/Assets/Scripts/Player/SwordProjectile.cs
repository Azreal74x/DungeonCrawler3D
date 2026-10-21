///sword projectile that damages enemies on contact or destroys itself after traveling a certain distance

using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class SwordProjectile : MonoBehaviour {

  public int damageStrength = 10;
  private float maxDistance = 5f;
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
      if (other.gameObject.CompareTag("Enemy")) {
        //Debug.Log("SwordProjectile hit enemy");
        Destroy(gameObject);
      }
      //Debug.Log("SwordProjectile collided! Destroying SwordProjectile object");
    }
  }
}
