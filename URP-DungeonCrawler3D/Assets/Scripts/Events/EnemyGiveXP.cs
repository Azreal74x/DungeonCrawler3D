///observer pattern for enemy die event to give player XP when enemy dies

using UnityEngine;

public class EnemyGiveXP : MonoBehaviour {

  private GameObject player;
  public Health health;

  private XP xp;
  [SerializeField] private float xpAmount;

  void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
      xp = player.GetComponent<XP>();
    }
  }

  private void OnEnable() {
    health.onDie += GiveXP;
  }

  private void OnDisable() {
    health.onDie -= GiveXP;
  }

  private void GiveXP() {
    if (xp != null) {
      xp.AddXP(xpAmount);

    }
  }
}
