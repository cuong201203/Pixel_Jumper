using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource dieeffect;
    private bool isDead = false; // Thêm biến trạng thái isDead

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        // Đánh dấu nhân vật là đã chết
        isDead = true;
        dieeffect.Play();
        anim.SetTrigger("death");
        // Ngăn không cho nhân vật tiếp tục di chuyển
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
