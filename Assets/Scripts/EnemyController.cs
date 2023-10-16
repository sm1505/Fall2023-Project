using UnityEngine;


public class EnemyController : MonoBehaviour{
    //Goomba enemy should walk through the player and we should be able to use this script for all enemies. we can create a string that has a dropdown of values in inspector that changes what type of enemy it is. Can also be an int if we want to do that for testing. lmk if you have questions -c
    [SerializeField] private int health;
    
    [SerializeField] private int moveSpeed;

    [SerializeField] SpriteRenderer sprite;

    Animator animator;

    //true is forward, false is backwards
    private bool direction;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if (direction){
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (health < 0){
            Destroy(this);
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag != "Player" && direction){
            direction = false;
        }
        else if (other.gameObject.tag != "Player" && !direction){
            direction = true;
        }
    }

    public void TakeDamage(int damageTaken){
        health = health - damageTaken;
        animator.SetBool("Attacked", true);
    }
}
