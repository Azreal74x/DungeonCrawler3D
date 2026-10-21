///manages quest progress for kill and key collection quests

using UnityEngine;
using System;
using System.Collections.Generic;

public class Quests : MonoBehaviour {

  public int killCount = 0;
  public int keyCount = 0;

  public int maxKillCount = 10;
  public int maxKeyCount = 1;

  private int currentKillCount = 0;

  public Action onDie;

  Inventory inventory;
  [SerializeField] ItemTypeSO keySO;

  public Action killQuestNewKill;
  public Action killQuestComplete;
  public Action keyQuestComplete;

  void Start() {
    inventory = GetComponent<Inventory>();
    currentKillCount = 0;
  }

  void Update() {
    KillQuestCheck();
    KeyQuestCheck();
  }

  void KillQuestCheck() {
    if(killCount > maxKillCount) {
      return;
    }
    else if (killCount > currentKillCount) {
      currentKillCount = killCount;
      killQuestNewKill.Invoke();
    }

    if (killCount == 10) {
      killQuestComplete.Invoke();
      //Debug.Log("Kill Quest Complete!");
    }
  }

  void KeyQuestCheck() {
    if (inventory.items.ContainsKey(keySO)) {
      if(keyCount >= maxKeyCount) {
        return;
      }
      else {
        keyCount += 1;
      }
      keyQuestComplete.Invoke();
      //Debug.Log("Key Quest Complete!");
    }

  }
}
