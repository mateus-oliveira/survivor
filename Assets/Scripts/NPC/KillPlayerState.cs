using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// No estado KillPlayer, o NPC persegue o jogador
public class KillPlayerState : NPCState
{   
    private int losingLife = 50;
    private bool isFollowingPlayer;
    private Vector3 distanceToPlayer;
    public KillPlayerState(NPC npc) : base(npc) { }

    public override void Enter()
    {
        // Lógica de entrada para o estado KillPlayer
        Debug.Log("Entrou no estado KillPlayer");
        isFollowingPlayer = true;
    }

    public override void Update()
    {
        // Verifique se o jogador está à vista
        Debug.Log("Matando Player");
        
        if (!isFollowingPlayer && npc.GetLife() >= losingLife) {
            npc.ChangeState(npc.GetOnGuardState());
        }
        else if (npc.GetLife() < losingLife) {
            npc.ChangeState(npc.GetToEscapeState());
        }

        distanceToPlayer = npc.GetPlayerPosition() - npc.transform.position;
        distanceToPlayer.Normalize();
        npc.transform.Translate(distanceToPlayer * 5 * Time.deltaTime);
    }

    public override void Exit()
    {
        // Lógica de saída para o estado KillPlayer
        Debug.Log("Saiu do estado KillPlayer");
    }

    private bool PlayerIsInSight()
    {
        // Implemente a lógica para verificar se o jogador está visível ao NPC
        return false;
    }


    // TODO
    public override void HandleCollision(Collider2D other) {
        //Debug.Log("Matei!!!");
    }

    public override void CollisionFinished(Collider2D other) {
        isFollowingPlayer = false;
    }


}
