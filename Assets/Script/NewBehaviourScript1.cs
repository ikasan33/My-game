using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float speed;
    public gamemanager manager;

    Animator anim;
    Rigidbody2D rigid;
    float h;
    float v;
    Vector3 dirVec;
    GameObject scanObject;
    bool isHorizonMove;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<gamemanager>(); // gamemanager ��ü�� ã�Ƽ� �Ҵ��մϴ�.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // manager.isAction�� null�� �ƴ��� Ȯ���ϰ� �����մϴ�.
        h = manager != null && manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager != null && manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // manager.isAction�� null�� �ƴ��� Ȯ���ϰ� �����մϴ�.
        bool hDown = manager != null && manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager != null && manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager != null && manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager != null && manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (anim.GetInteger("vAxisRaw") != v) 
        {
             anim.SetBool("isChange", true);
             anim.SetInteger("vAxisRaw", (int)v); 
        }
        else if
            (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        
        else
            anim.SetBool("isChange", false);



        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.left;
        else if (hDown && h == -1)
            dirVec = Vector3.right;

        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

    }
     void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        Debug.DrawRay(rigid.position, dirVec * 1.1f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.1f, LayerMask.GetMask("object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
