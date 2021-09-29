using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public float restartDelay = 5f;
    public Text warningText;
    bool isDead;

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
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}