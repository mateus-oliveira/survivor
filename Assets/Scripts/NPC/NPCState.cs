using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPCState {
    protected NPC npc;

    public NPCState(NPC npc) {
        this.npc = npc;
    }

    public abstract void HandleCollision(Collider2D other);

    public abstract void CollisionFinished(Collider2D other);

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
