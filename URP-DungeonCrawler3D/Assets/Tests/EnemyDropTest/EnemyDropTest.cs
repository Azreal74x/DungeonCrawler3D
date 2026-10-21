using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDropTest : MonoBehaviour {

  [SerializeField] GameObject enemyPrefab;
  [SerializeField] string enemyTag = "enemyTag";

  private GameObject enemy;

  private Vector3 enemyPosition;
  private quaternion enemyRotation;

  [SerializeField] private Inventory inventory;
  [SerializeField] private ItemTypeSO itemType;

  private bool enemyDead = false;
  private bool dropPickedUp = false;
  private GameObject currentDrop;


  void Start() {
    enemy = GameObject.FindGameObjectWithTag(enemyTag);

    enemyPosition = enemy.transform.localPosition;
    enemyRotation = enemy.transform.rotation;
  }

  void Update() {

  }

  public void KillEnemy() {
    if (enemy != null) {
      Health enemyHealth = enemy.GetComponent<Health>();
      enemyHealth.GetHit((int)enemyHealth.GetCurrentHealth(), " ");
      
      enemyDead = true;
      dropPickedUp = false;
      currentDrop = enemy.GetComponent<EnemyDrop>().GetDrop();
    }
    else {
      Debug.Log("Current enemy is dead!");
    }
  }

  public void RespawnEnemy() {
    if (enemy == null) {
      GameObject newEnemy = Instantiate(enemyPrefab, enemyPosition, enemyRotation);

      newEnemy.gameObject.tag = enemyTag;
      enemy = GameObject.FindGameObjectWithTag(enemyTag);
      newEnemy.GetComponent<EnemyAttack>().enabled = false;
      newEnemy.GetComponent<EnemyMovement>().enabled = false;
      newEnemy.GetComponent<EnemyDamageReceiver>().enabled = false;
      newEnemy.GetComponent<NavMeshAgent>().enabled = false;
      newEnemy.GetComponent<Rigidbody>().useGravity = false;

      enemyDead = false;
      dropPickedUp = false;
      currentDrop = null;
    }
    else {
      Debug.Log("Current enemy is not dead!");
    }
  }

  public void PickupDrop() {
    if (!enemyDead) {
      return;
    }
    if (dropPickedUp) {
      return;
    }
    if (currentDrop == null) {
      return;
    }

    inventory.Add(itemType);
    Destroy(currentDrop);
    dropPickedUp = true;
  }
}
