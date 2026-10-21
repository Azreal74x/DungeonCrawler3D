///enemy movement strategies activated and setting the walking animation

using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
  [SerializeField] GameObject player;

  [SerializeField] private Animator animator;
  //private string[] animations = { "idle01", "idle02", "Walk", "getHit", "die", "Basic Attack", "Claw Attack" };

  [SerializeField] private ScriptableObject movementStrategyObject;
  private IMovementStrategy movementStrategy;

  private NavMeshAgent agent;

  private void Awake() {
   movementStrategy = movementStrategyObject as IMovementStrategy;
  }

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    agent = GetComponent<NavMeshAgent>();
  }

  private void Update() {
    Move();
  }

  private void Move() {
    //GetComponent<NavMeshAgent>().destination = player.transform.position;
    movementStrategy.Move(gameObject,player);

    bool isMoving = agent.velocity.sqrMagnitude > 0.01f && !agent.isStopped;
    animator.SetBool("isWalking", isMoving);
  }

  public Vector3 GetPosition() {
    return transform.position;
  }
}

//future animation ideas
//idle01-idle02
//player in range -> Walk
//player in attack range -> Basic Attack
//player attacks back -> getHit
//die -> die
//extra: after player attacks back, player in attack range -> Claw Attack

