using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3;
    public float jump = 10;
    
    public float jumpCooldownTime = 1f; // เวลา cooldown สำหรับการโดด
    private float jumpCooldownTimer = 0f; // ตัวเลขนับเวลา cooldown สำหรับการโดด
    // ...
    
    private SpriteRenderer spriteRenderer;

    public CoinManager cm;

    // // ประกาศตัวแปรสำหรับเลือด
    // private int health = 100; // ค่าเริ่มต้นเลือดคือ 100

    

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent< Rigidbody2D >(); 
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
    rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);
    
    if (move != 0)
    {
        spriteRenderer.flipX = move < 0f; // พลิป Sprite ถ้า move มีค่าน้อยกว่า 0
    }

    if (jumpCooldownTimer > 0)
    {
        jumpCooldownTimer -= Time.deltaTime;
    }

    if (Input.GetKeyDown(KeyCode.Space) && jumpCooldownTimer <= 0)
    {
        Jump();
        jumpCooldownTimer = jumpCooldownTime;
    }

        
        
    }

    void Jump()
    {
        // โค้ดสำหรับการโดดขึ้น โดยใช้ Rigidbody2D.AddForce หรือ Rigidbody2D.velocity
        rb2D.AddForce( new Vector2 (0 , jump) ,ForceMode2D.Impulse );
    }

    // public void TakeDamage(int damageAmount)
    // {
    //     health -= damageAmount;
    //     // เช็คเงื่อนไขว่าเลือดน้อยกว่าหรือเท่ากับ 0 หรือไม่
    //     if (health <= 0)
    //     {
    //         // เรียกใช้ฟังก์ชันสำหรับการเสียชีวิต
    //         Die();
    //     }
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Obstacle")) // แสดงว่ามีการชนกับออบเจกต์ที่มี Tag เป็น "Obstacle"
    //     {
    //         // เรียกใช้ฟังก์ชัน TakeDamage() โดยส่งค่าเรายดเป็นอาเรย์ของเลือดที่จะลด
    //         TakeDamage(10); // ตัวอย่างการลดเลือดที่ 10
    //     }
    // }

    // private void Die()
    // {
    //     // เพิ่มการปิดการทำงานของ Player หรือทำการ Restart เกม ตามที่ต้องการ
    //     gameObject.SetActive(false); // ตัวอย่างการปิดการทำงานของ Player
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
