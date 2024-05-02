using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    // ประกาศตัวแปร rb2d

    void Start()
    {
        // // กำหนดค่าให้กับ rb2d โดยการรับอ้างอิงจากคอมโพเนนต์ Rigidbody2D ที่แนบกับ GameObject เดียวกัน
        // rb2d = GetComponent<Rigidbody2D>();

        // // ตอนนี้คุณสามารถใช้ rb2d ในโค้ดของคุณได้อย่างปลอดภัย
        // if (rb2d != null)
        // {
        //     // ทำสิ่งที่คุณต้องการกับ rb2d ได้แล้ว
        // }
        // else
        // {
        //     Debug.LogError("ไม่พบคอมโพเนนต์ Rigidbody2D บน GameObject.");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb2d.velocity = new Vector2(moveHorizontal, rb2d.velocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = moveHorizontal < 0;
        }

        animator.SetBool("IsPlayerRun", Mathf.Abs(moveHorizontal) > 0);
    }
}
