using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMove;

    public float restartDelay = 5f;
    public Text warningText;
    bool isDead;
    bool healing;
    bool speeding;

    Animator anim;                          
    float restartTimer;



    void Awake()
    {
        anim = GetComponent<Animator>();
        isDead = false;
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            if (isDead == false)
            {
                anim.SetTrigger("GameOver");
                Debug.Log("abis");
                isDead = true;
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        healing = false;
        speeding = false;
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }

    public void Speed()
    {
        speeding = true;
        StartCoroutine(SpeedUp());
    }

    IEnumerator SpeedUp()
    {
        playerMove.speed = 20f;

        yield return new WaitForSeconds(3f);

        playerMove.speed = 6f;
    }

    public void Healing()
    {
        if (playerHealth.currentHealth < 100)
        {
            healing = true;
            playerHealth.currentHealth = playerHealth.currentHealth + 30;
            playerHealth.healthSlider.value = playerHealth.currentHealth;
        }
    }
}