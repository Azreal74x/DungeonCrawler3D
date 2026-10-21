///health potion item type scriptable object strategy

using UnityEngine;

[CreateAssetMenu(menuName = "ItemType/HealthPotion")]
public class HealthPotionSO : ItemTypeSO {
  public int healAmount = 50;

  public override void Use(GameObject player) {
    Health playerHealth = player.GetComponent<Health>();
    playerHealth.UseHealthPotion();
  }
}