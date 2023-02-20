using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCollect : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public Player playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject endPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) 
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            
            playerController.runningSpeed = 0;

            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            endPanel.SetActive(true);

            if (score >= maxScore)
            {               
                PlayerAnim.SetBool("win", true);                
            }
            else
            {               
                PlayerAnim.SetBool("lose", true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
