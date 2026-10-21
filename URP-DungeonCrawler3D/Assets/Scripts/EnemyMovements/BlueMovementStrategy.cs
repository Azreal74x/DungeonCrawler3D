///blue movement strategy to make it follow the player using navmeshagent

using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "MovementStrategy/BlueMovement")]
public class BlueMovementStrategy : ScriptableObject, IMovementStrategy {

  public void Move(GameObject blue, GameObject player) {
    blue.GetComponent<NavMeshAgent>().destination = player.transform.position;
  }

}
