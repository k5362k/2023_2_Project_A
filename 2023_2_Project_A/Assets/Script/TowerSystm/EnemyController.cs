using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;

    private MonsterPath thePath;
    private int currntPoint;
    private  bool reachedEnd;

    // Start is called before the first frame update
    void Start()
    {
        if(thePath == null)
        {
            thePath = FindObjectOfType<MonsterPath>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedEnd == false)
        {
            transform.LookAt(thePath.points[currntPoint]);

            transform.position = Vector3.MoveTowards(transform.position, thePath.points[currntPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currntPoint].position) < 0.01f)
            {
                currntPoint += 1;
                if (currntPoint >= thePath.points.Length)
                {
                    reachedEnd = true;
                }
            }
        
        }
    }
}
