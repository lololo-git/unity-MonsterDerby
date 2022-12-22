using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Common.GlobalConst;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField] GameObject players;

    [SerializeField] GameObject prefabPink;
    [SerializeField] GameObject prefabDude;
    [SerializeField] GameObject prefabOwlet;

    public GameObject Generate(MonsterID mid, Vector2 position)
    {
        GameObject monster = null;

        if (mid == MonsterID.PINK)
            monster = Instantiate(prefabPink, players.transform);
        else if (mid == MonsterID.DUDE)
            monster = Instantiate(prefabDude, players.transform);
        else if (mid == MonsterID.OWLET)
            monster = Instantiate(prefabOwlet, players.transform);
        
        monster.transform.localPosition = position;
        return monster;
    }
}
