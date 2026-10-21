///purple movement strategy to make it stop at a certain distance and rotate towards player

using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "MovementStrategy/PurpleMovement")]
public class PurpleMovementStrategy : ScriptableObject, IMovementStrategy {

  [SerializeField] private float stopDistance = 20f;
  [SerializeField] private float rotationSpeed = 10f;

  public void Move(GameObject purple, GameObject player) {

    NavMeshAgent agent = purple.GetComponent<NavMeshAgent>();

    agent.destination = player.transform.position;
    agent.stoppingDistance = stopDistance;

    //turn enemy
    Vector3 direction = (player.transform.position - purple.transform.position).normalized;
    direction.y = 0;

    if (direction.sqrMagnitude > 0.001f) {
      purple.transform.rotation = Quaternion.Lerp(purple.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }

  }

}
