using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Common.GlobalConst;

public class GameSystem : MonoBehaviour
{
    [SerializeField] GameObject monsterGeneratorObject;
    [SerializeField] GameObject pathObject;
    [SerializeField] new Camera camera;
    
    Monster[] monsters;

    void Start()
    {
        var generator = monsterGeneratorObject.GetComponent<MonsterGenerator>();
        var path = pathObject.GetComponent<Path>();
        var monsterIDs = new MonsterID[] { MonsterID.PINK, MonsterID.DUDE, MonsterID.OWLET };
        var pos = new Vector2(-6, 7);
        monsters = new Monster[monsterIDs.Length];

        for(var i = 0; i < monsterIDs.Length; i++)
        {
            var monster = generator.Generate(monsterIDs[i], pos);
            monsters[i] = monster.GetComponent<Monster>();
            monsters[i].SetNextPoint(path.GetFirstPoint());
            pos.y += 0.5f;
        }
    }

    void FixedUpdate()
    {
        var pos = monsters[0].transform.position;
        pos.z = camera.transform.position.z;
        camera.transform.position = pos;
    }
}