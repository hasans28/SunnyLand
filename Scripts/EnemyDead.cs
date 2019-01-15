using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] public LayerMask targetLayer;
    [SerializeField] public Transform playerCheck;
    [SerializeField] private Collider2D deadCollider;

    public Text scoreText;

    const float radius = 0.8f;
    int score;

    public Animator anim;

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(playerCheck.position, radius, targetLayer)) {
            deadCollider.enabled = false;
            anim.SetBool("isDead", true);
            StartCoroutine(KillOnAnimationEnd());
        }
        return;
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.499f);
        Score();
        Destroy(gameObject);
    }

    void Score() {
        score = PlayerPrefs.GetInt("Score", 0);
        score++;
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = "Score:" + score;
        return;
    }

}
