using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float currHp;
    public float maxHp = 100;

    public float currMeleeDmg;
    public float currRangeDmg;
    public float maxDmg;

    // Start is called before the first frame update
    void Start()
    {
        currHp = maxHp;
    }

    public void takeDamage(float damage)
    {
        currHp -= damage;
    }

    public void restore(int restoreType, float restoreValue)
    {
        switch(restoreType)
        {
            // HP
            case 1:
                return;

            // MP
            case 2:
                return;

        }
    }
}
