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

    public Monster Generate(MonsterID mid, Vector2 position, Vector2 nextPoint)
    {
        GameObject monsterObject = null;

        if (mid == MonsterID.PINK)
            monsterObject = Instantiate(prefabPink, players.transform);
        else if (mid == MonsterID.DUDE)
            monsterObject = Instantiate(prefabDude, players.transform);
        else if (mid == MonsterID.OWLET)
            monsterObject = Instantiate(prefabOwlet, players.transform);

        monsterObject.transform.localPosition = position;
        var monster = monsterObject.GetComponent<Monster>();
        monster.SetNextPoint(nextPoint);

        return monster;
    }
}
