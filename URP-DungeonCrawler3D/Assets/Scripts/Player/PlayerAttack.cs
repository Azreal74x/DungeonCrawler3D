///handle player attack, including playing attack animations

using NUnit.Framework;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

  [SerializeField] private Animator animator;
  private string[] animations = { "slash1", "slash3", "slash8" };

  [SerializeField] private float attackCooldown = 1.5f;

  [SerializeField] private GameObject swordProjectile;

  private int lastAttackIndex = -1;

  //private bool tryAttack = false;
  private bool canAttack = true;

  public int swordStrength = 10;

  private void Start() {

  }

  private void Update() {
    //CheckKeyInputForAnimation();
    //CheckKeyInput();

    if (Input.GetMouseButtonDown(0) && canAttack) {
      StartCoroutine(Attack());

    }

  }
  private IEnumerator Attack() {
    canAttack = false;

    PlayAttackAnimation();
    SendSwordProjectile();

    yield return new WaitForSeconds(attackCooldown);
    canAttack = true;
  }

  private void SendSwordProjectile() {
    // Convert mouse position to a point in the world
    Vector3 mousePos = Input.mousePosition;
    mousePos.z = 10f; // distance from camera to world point
    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

    // Direction from shooter click point
    Vector3 direction = (worldPos - transform.position).normalized;

    // Create the projectile
    GameObject projectile = Instantiate(swordProjectile, transform.position, Quaternion.identity);

    // Apply velocity
    Rigidbody rb = projectile.GetComponent<Rigidbody>();
    //* speed
    rb.linearVelocity = direction * 20f;

    // Optional: rotate projectile toward direction
    projectile.transform.forward = direction;

    projectile.GetComponent<SwordProjectile>().damageStrength = swordStrength;
  }
  private void PlayAttackAnimation() {
    //Debug.Log("playing animation");
    int randomNumber;

    do {
      randomNumber = Random.Range(0, animations.Length);
    } while (randomNumber == lastAttackIndex && animations.Length > 1);

    lastAttackIndex = randomNumber;

    animator.SetTrigger(animations[randomNumber]);
  }

  /*private void CheckKeyInput() {
    if (Input.GetMouseButtonDown(0)) {
      tryAttack = true;
    }
    else {
      tryAttack = false;
    }
  }*/

  private void CheckKeyInputForAnimation() {
    if (Input.GetKeyDown("1")) { //<-1
      animator.SetTrigger("slash1");
    }
    if (Input.GetKeyDown("2")) {
      animator.SetTrigger("slash2");
    }
    if (Input.GetKeyDown("3")) { //<-3
      animator.SetTrigger("slash3");
    }
    if (Input.GetKeyDown("4")) {
      animator.SetTrigger("slash4");
    }
    if (Input.GetKeyDown("5")) {
      animator.SetTrigger("slash5");
    }
    if (Input.GetKeyDown("6")) {
      animator.SetTrigger("slash6");
    }
    if (Input.GetKeyDown("7")) {
      animator.SetTrigger("slash7");
    }
    if (Input.GetKeyDown("8")) { //<-8
      animator.SetTrigger("slash8");
    }
    if (Input.GetKeyDown("9")) {
      animator.SetTrigger("slash9");
    }
  }
}
