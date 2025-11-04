using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnGuardState : NPCState
{
    private bool playerIsInSight;

    public OnGuardState(NPC npc) : base(npc) { }

    public override void Enter() {
        playerIsInSight = false;
        Debug.Log("Entrou no estado OnGuard");
    }

    public override void Update()
    {
        Debug.Log("Estou ativooo!!!!");
        if (playerIsInSight)
        {
            npc.ChangeState(npc.GetKillPlayerState());
        }
    }


    public override void Exit()
    {
        Debug.Log("Saiu do estado OnGuard");
    }


    public override void HandleCollision(Collider2D other) {
        Debug.Log("Colidindo");
        if (other.CompareTag("Player") && !playerIsInSight) {
            playerIsInSight = true;
        }
    }

    public override void CollisionFinished(Collider2D other) {
    }
}
