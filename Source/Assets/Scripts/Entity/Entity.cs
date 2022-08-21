using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Entity : NetworkBehaviour
{
    [SerializeField]public Animator anim;
    [SerializeField]protected float maxSpeed;

    [HideInInspector]public Transform target;
    private Vector3 movePosition;
    private float thinkTime;

    protected virtual void Start()
    {
        movePosition = transform.position;
    }


    protected virtual void Update()
    {
        SetRandomMovePosition();
        MoveControl();
    }

    protected virtual void LateUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 dist = movePosition - transform.position;

        float angle = Mathf.Atan2(dist.x, dist.z) * Mathf.Rad2Deg;
        float rot = Mathf.LerpAngle(transform.eulerAngles.y, angle, Time.deltaTime * 1);

        transform.eulerAngles = new Vector3(0, rot, 0);
    }

    public void CheckTarget()
    {
        if (!TargetCheck()) return;
    }

    public virtual void MoveControl()
    {
        Vector3 diff = movePosition - transform.position;

        if (Vector2.Distance(movePosition, transform.position) <= 0.5f)
        {
            return;
        }

        diff.Normalize();
        Move(diff.x, diff.z);
    }

    void SetRandomMovePosition()
    {
        if (TargetCheck()) return;

        thinkTime += Time.deltaTime;
        if(thinkTime >= 3)
        {
            float x = Random.Range(transform.position.x - 3, transform.position.x + 3);
            //float y = Random.Range(transform.position.y - 3, transform.position.y + 3);
            float z = Random.Range(transform.position.z - 3, transform.position.z + 3);

            movePosition = new Vector3(x, 0, z);
            thinkTime = 0;
        }
    }

    public void Move(float x, float z)
    {
        if (!isLocalPlayer) return;

        Vector3 normalMove = new Vector3(x, 0, z).normalized;

        //if(x != 0 && z != 0){
            
        //}

        if(anim != null) anim.SetFloat("Move", normalMove.magnitude);

        //transform.position += normalMove * Time.deltaTime;
        transform.Translate(normalMove * maxSpeed * Time.deltaTime);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            target = player.transform;
        }
    }

    public bool TargetCheck()
    {
        return target;
    }
}
