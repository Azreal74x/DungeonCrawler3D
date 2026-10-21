///maka sure player has key and no enemies are close to escape

using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {

  public static GameObject[] enemies;

  [SerializeField] ItemTypeSO keySO;

  void Start() {

  }

  void Update() {
  }

  void CheckEscape(Inventory inventory, GameObject player) {
    if (!inventory.items.ContainsKey(keySO)) {
      return;
    }

    enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //Debug.Log(enemies.Length + " enemies found in the scene.");

    foreach (var enemy in enemies) {
      if (Vector3.Distance(enemy.transform.position, player.transform.position) < 20f) {
        //Debug.Log("Enemies too close to escape!");
        return;
      }
    }

    SceneManager.LoadScene("WinScene");
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      Inventory playerInventory = other.GetComponent<Inventory>();
      //Debug.Log("player colliding with door");
      CheckEscape(playerInventory, other.gameObject);
    }
  }
}
