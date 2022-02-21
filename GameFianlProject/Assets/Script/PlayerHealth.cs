using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int blinks;
    public float time;
    public float dieTime;
    private Renderer myRender;
    private ScreenFlash sf;
    private Animator anim;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRender = GetComponent<Renderer>();
    }
    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.healthCurrent = health;
        if (health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);
            GameController.isGameAlive = false;
            anim.SetTrigger("Die");
            Invoke("killPlayer", dieTime);
        }
        BinkPlayer(blinks, time);
    }

    void killPlayer()
    {
        GameController.Instance.ShowGameOverPanel();
        Destroy(gameObject);
    }
    void BinkPlayer(int numBilink, float seconds)
    {
        StartCoroutine(DoBlink(numBilink, seconds));
    }

    IEnumerator DoBlink(int numBilink, float seconds)
    {
        for (int i = 0; i < numBilink * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
