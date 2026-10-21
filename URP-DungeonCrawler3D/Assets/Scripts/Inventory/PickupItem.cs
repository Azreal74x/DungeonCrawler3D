///lest the player be able to pick up items and add them to their inventory

using NUnit.Framework.Interfaces;
using UnityEngine;

public class PickupItem : MonoBehaviour {

  public ItemTypeSO itemType;

  private void Start() {

  }

  private void Update() {

  }

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      other.GetComponent<Inventory>().Add(itemType);
      Destroy(gameObject);
    }
  }
}
