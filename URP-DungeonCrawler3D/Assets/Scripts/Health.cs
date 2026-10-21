///manages the health of both player and enemy, including taking damage and power ups

using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;
using System;
using System.Collections;

public class Health : MonoBehaviour {

  [SerializeField] private float currentHealth = 100;
  [SerializeField] private float maxHealth = 100;

  [SerializeField] private HealthBar healthBar;
  private bool burnResistanceActive = false;

  private bool isDead = false;

  public Action onDie;
  public Action gameOver;
  public Action playerHurt;
  public Action healthPotion;
  public Action burnResistance;

  Animator animator;

  private void Start() {
    if (GetComponent<Animator>() != null) {
      animator = GetComponent<Animator>();
    }
    SetMaxHealth();
  }

  private void Update() {
    if (currentHealth > maxHealth) {
      currentHealth = maxHealth;
    }

    if (Input.GetKeyDown("b")) {
      animator.SetTrigger("Get Hit");
    }
  }

  public float GetCurrentHealth() {
    return currentHealth;
  }

  public void GetHit(int damage, string damageType) {
    if(damageType == "Fireball" && burnResistanceActive) {
      return;
    }

    if (animator != null && currentHealth > 0) {
      animator.SetTrigger("Get Hit");
    }

    currentHealth -= damage;
    healthBar.SetHealthBar(currentHealth);
    playerHurt?.Invoke();
    //Debug.Log("got hit, health is now: " +  currentHealth); 

    if (currentHealth <= 0 && !isDead) {
      currentHealth = 0;
      onDie?.Invoke();
      gameOver?.Invoke();
      isDead = true;
    }
  }

  private void SetMaxHealth() {
    currentHealth = maxHealth;
    healthBar.SetMaxHealthBar(maxHealth);
    healthBar.SetHealthBar(currentHealth);
  }

  public void UseHealthPotion() {
    if (Input.GetKeyDown("1")) {
      currentHealth += 50f;
      healthBar.SetHealthBar(currentHealth);
      healthPotion?.Invoke();
    }
  }

  public void UseBurnResistance() {
    if (Input.GetKeyDown("2") && !burnResistanceActive) {
      StartCoroutine(BurnResistanceTimer());

      healthBar.SetHealthBar(currentHealth);
    }
  }

  private IEnumerator BurnResistanceTimer() {
    burnResistanceActive = true;
    burnResistance?.Invoke();

    yield return new WaitForSeconds(10f);

    burnResistanceActive = false;
  }
}
