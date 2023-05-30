using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathFinding;
    private SpriteRenderer mySpriteRenderer;

    private void Awake() 
    {
        enemyPathFinding = GetComponent<EnemyPathfinding>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        state = State.Roaming;
    }

    private void Start() 
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            //Debug.Log(GetRoamingPosition());
            enemyPathFinding.MoveTo(roamPosition);

            //flip sprite of the enemy
            if (roamPosition.x < 0)
            {
                mySpriteRenderer.flipX = true;
            }
            else
            {
                mySpriteRenderer.flipX = false;
            }

            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }    
}
