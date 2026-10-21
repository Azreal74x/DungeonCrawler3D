///xp manager for player leveling up and increasing sword strength.

using UnityEngine;
using System;

public class XP : MonoBehaviour {

  [SerializeField] private float currentXP = 0;
  [SerializeField] private float xpToNextLevel = 100;

  [SerializeField] private float xpMultiplier = 1.5f;
  [SerializeField] private int swordStrengthIncrease = 5;


  [SerializeField] private XPBar xpBar;
  private int level = 0;

  PlayerAttack playerAttack;

  void Start() {
    playerAttack = GetComponent<PlayerAttack>();
    ResetCurrentXP();
    xpBar.ResetXPBar(xpToNextLevel, level);
  }

  void Update() {
    LevelUp();
  }

  public void AddXP(float xpAmount) {
    currentXP += xpAmount;
    xpBar.SetXPBar(currentXP, level);
  }

  private void LevelUp() {
    if (currentXP >= xpToNextLevel) {
      currentXP -= xpToNextLevel;
      xpToNextLevel *= xpMultiplier;
      level++;
      xpBar.ResetXPBar(xpToNextLevel, level);
      xpBar.SetXPBar(currentXP, level);
      playerAttack.swordStrength += swordStrengthIncrease;
    }
  }

  public void ResetCurrentXP() {
    currentXP = 0;
  }

  public void ResetXPStats() {
    currentXP = 0;
    xpToNextLevel = 100;
    level = 0;
    xpBar.ResetXPBar(xpToNextLevel, level);
    playerAttack.swordStrength = 10;
  }

}
