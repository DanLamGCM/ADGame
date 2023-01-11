using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    Vector3 moveDirection;
    public GameObject map;
    public Clock clk;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorHandler animatorHandler; 

    public new Rigidbody rigidbody;

    [Header("Stats")]
    [SerializeField]
    float rotationSpeed = 10;

    private NavMeshAgent agent;
    public Transform targetTrans;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetTrans.position;

        clk = GameObject.FindWithTag("Clock").GetComponent<Clock>();

        rigidbody = GetComponent<Rigidbody>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        myTransform = transform;
        animatorHandler.Initialize();
    }

    public void Update()
    {
        float delta = Time.deltaTime;
        //agent.destination = targetTrans.position;
        if(clk.curTime.Minutes%2 == 0)
        {
            agent.destination = map.transform.Find("Room One Nav").transform.position;
        }
        else 
        {
            agent.destination = map.transform.Find("Room Two Nav").transform.position;
        }
        HandleMovementAnim(delta);
    }

    #region Movement
    Vector3 normalVector;
    Vector3 targetPosition;

    private void HandleMovementAnim(float delta)
    {
        animatorHandler.UpdateAnimatorValues(agent.velocity.magnitude / 3.5f, 0);
        if(animatorHandler.canRotate) HandleRotation(delta);            
    }

    private void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = agent.velocity;
        targetDir.Normalize();
        targetDir.y = 0;

        float rs = rotationSpeed;

        if(targetDir != Vector3.zero)
        {
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs*delta);
            myTransform.rotation = targetRotation;
        }

    }
    #endregion



}
