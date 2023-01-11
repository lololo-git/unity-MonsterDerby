using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Common.GlobalConst;

public class GameSystem : MonoBehaviour
{
    [SerializeField] MonsterGenerator generator;
    [SerializeField] Turf turf;
    [SerializeField] new Camera camera;

    Monster[] monsters;
    Monster player;

    void Start()
    {
        var monsterIDs = new MonsterID[] { MonsterID.PINK, MonsterID.DUDE, MonsterID.OWLET };
        monsters = new Monster[monsterIDs.Length];
        for(var i = 0; i < monsterIDs.Length; i++)
            monsters[i] = generator.Generate(monsterIDs[i], turf.GetBarrierPoint(i), turf.GetFirstPoint());
        player = monsters[0];
    }

    void FixedUpdate()
    {
        var pos = player.gameObject.transform.position;
        pos.z = camera.transform.position.z;
        camera.transform.position = pos;
    }
}