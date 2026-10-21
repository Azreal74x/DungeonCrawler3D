///observer pattern event to update player quest kill count

using UnityEngine;

public class EnemyKilled : MonoBehaviour {

  GameObject player;
  Quests playerQuests;
  public Health health;

  void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
      playerQuests = player.GetComponent<Quests>();
    }
  }

  private void OnEnable() {
    health.onDie += AddToQuest;
  }

  private void OnDisable() {
    health.onDie -= AddToQuest;
  }

  private void AddToQuest() {
    if (playerQuests != null) {
      playerQuests.killCount += 1;
      Debug.Log("killCount is now: " + playerQuests.killCount);
    }
  }
}
