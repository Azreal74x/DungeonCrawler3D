///strategy pattern for red movement following player after it triggered the collider for the final boss area fight

using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "MovementStrategy/RedMovement")]
public class RedMovementStrategy : ScriptableObject, IMovementStrategy {

  public void Move(GameObject red, GameObject player) {
    if (player.GetComponent<PlayerMovement>().redTriggered == true) {
      red.GetComponent<NavMeshAgent>().destination = player.transform.position;
    }
  }

}
