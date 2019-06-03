using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerChar : MonoBehaviour
{
    public Camera MyCamera;
    public LayerMask PointAndClickMask = Physics.AllLayers;

    protected NavMeshAgent _agent;
    protected Coroutine _interactAfterWalkRoutine;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MyCamera && !DialogueUIManager.Instance.IsActive)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray camRay = MyCamera.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(camRay, out hitInfo, 100.0f, PointAndClickMask, QueryTriggerInteraction.Ignore))
            {
                Vector3 worldPos = hitInfo.point;

                if(_interactAfterWalkRoutine != null)
                {
                    StopCoroutine(_interactAfterWalkRoutine);
                    _interactAfterWalkRoutine = null;
                }

                Interactable interact = hitInfo.transform.GetComponent<Interactable>();
                if(interact)
                {
                    if(interact.interactionWalkLocation)
                    {
                        worldPos = interact.interactionWalkLocation.position;
                    }
                    _interactAfterWalkRoutine = StartCoroutine(InteractAfterWalk(interact));
                }

                //Debug.DrawRay(worldPos - (Vector3.up * 0.5f), Vector3.up, Color.red, 1.0f);
                //Debug.DrawRay(worldPos - (Vector3.right * 0.5f), Vector3.right, Color.red, 1.0f);
                //Debug.DrawRay(worldPos - (Vector3.forward * 0.5f), Vector3.forward, Color.red, 1.0f);

                _agent.SetDestination(worldPos);
            }
        }
    }

    protected IEnumerator InteractAfterWalk(Interactable interact)
    {
        //https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html?childToView=746157#answer-746157
        bool run = true;

        while(run)
        {
            run = !(_agent.remainingDistance <= _agent.stoppingDistance && (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0.0f));
            yield return null;
        }
        
        Vector3 lookAtPos = interact.transform.position;
        lookAtPos.y = transform.position.y;
        transform.forward = lookAtPos - transform.position;
        interact.InteractWith(gameObject);
        _interactAfterWalkRoutine = null;
    }
}
