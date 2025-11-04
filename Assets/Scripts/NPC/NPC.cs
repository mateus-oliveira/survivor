using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    private int maxLife = 100;
    private NPCState currentState;
    private OnGuardState onGuardState;
    private KillPlayerState killPlayerState;
    private ToEscapeState toEscapeState;
    [SerializeField] private int life = 100;
    [SerializeField] private int damageAmount = 10;
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
        onGuardState = new OnGuardState(this);
        killPlayerState = new KillPlayerState(this);
        toEscapeState = new ToEscapeState(this);

        currentState = onGuardState;
        currentState.Enter();
    }

    private void Update() {
        currentState.Update();
    }

    public void ChangeState(NPCState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void AddToLife(int life) {
        this.life += life;
        if (this.life > maxLife) {
            this.life = maxLife;
        }
        if (this.life < 0) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        currentState.HandleCollision(other);
    }

    public void OnTriggerExit2D(Collider2D other) {
        currentState.CollisionFinished(other);
    }

    // Getters and Setters
    public OnGuardState GetOnGuardState(){
        return this.onGuardState;
    }

    public KillPlayerState GetKillPlayerState(){
        return this.killPlayerState;
    }

    public ToEscapeState GetToEscapeState(){
        return this.toEscapeState;
    }

    public int GetLife(){
        return this.life;
    }

    public void SetLife(int life){
        if (life > maxLife){
            this.life = maxLife;
        } else if (life < 0) {
            this.life = 0;
        } else {
            this.life = life;
        }
    }

    public Vector3 GetPlayerPosition(){
        if (player != null)
        {
            return player.transform.position;
        }
        return Vector3.zero;
    }

    public int GetDamageAmount(){
        return damageAmount;
    }
}
