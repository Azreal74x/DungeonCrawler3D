/// burn resistance item type strategy

using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "ItemType/BurnResistance")]
public class BurnResistanceSO : ItemTypeSO {

  public override void Use(GameObject player) {
    Health playerHealth = player.GetComponent<Health>();
    playerHealth.UseBurnResistance();
    Debug.Log("burn resistance used");
  }
}
