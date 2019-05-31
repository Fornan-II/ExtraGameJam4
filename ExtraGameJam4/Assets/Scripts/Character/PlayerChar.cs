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

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MyCamera)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray camRay = MyCamera.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(camRay, out hitInfo, 100.0f, PointAndClickMask, QueryTriggerInteraction.Ignore))
            {
                Vector3 worldPos = hitInfo.point;

                //Debug.DrawRay(worldPos - (Vector3.up * 0.5f), Vector3.up, Color.red, 1.0f);
                //Debug.DrawRay(worldPos - (Vector3.right * 0.5f), Vector3.right, Color.red, 1.0f);
                //Debug.DrawRay(worldPos - (Vector3.forward * 0.5f), Vector3.forward, Color.red, 1.0f);

                _agent.SetDestination(worldPos);
            }
        }
    }
}
