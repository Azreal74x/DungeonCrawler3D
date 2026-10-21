//observer pattern event making enemy newDrop item on death

using UnityEngine;

public class EnemyDrop : MonoBehaviour {
  [SerializeField] private GameObject dropItem;
  private GameObject player;
  public Health health;

  private GameObject currentDrop;

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  private void OnEnable() {
    health.onDie += DropItem;
  }

  private void OnDisable() {
    health.onDie -= DropItem;
  }

  private void DropItem() {
    //print(transform.position);
    //GameObject newDrop = Instantiate(dropItem, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    //GameObject newDrop = Instantiate(dropItem, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity);
    //GameObject newDrop = Instantiate(dropItem, transform.position, Quaternion.identity);
    GameObject newDrop = Instantiate(dropItem, new Vector3(transform.position.x, player.transform.position.y - 1, transform.position.z), Quaternion.identity);
    currentDrop = newDrop;
  }

  public GameObject GetDrop() {
    return currentDrop;
  }

}
