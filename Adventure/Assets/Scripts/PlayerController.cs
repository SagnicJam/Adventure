using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    //on point click set the position where the player has to go
    //use a* path finding for the players to navigate
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        lastPlayerPosition = transform.position;
    }

    Vector2 lastClickedPosition;
    Vector3 lastPlayerPosition;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPlayerPosition = transform.position;

            //agent.velocity = Vector3.zero;

            agent.SetDestination(lastClickedPosition);
        }

        if (transform.position !=lastPlayerPosition)
        {
            //Debug.Log("moving");
            transform.localScale = new Vector3(Mathf.Sign((transform.position - lastPlayerPosition).x)
                , transform.localScale.y
                , transform.localScale.z);
            lastPlayerPosition = transform.position;
        }
    }
}
