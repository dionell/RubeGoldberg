using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

    public Image blackImage;
    public Animator anim;
    public WinGame winGame;
    public BallReset ballReset;
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball" && winGame.levelComplete)
        {
            StartCoroutine(Fading());
        }
        else if(winGame.levelComplete == false)
        {
            ballReset.BallResetPosition();
        }
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackImage.color.a == 1); //wait until image's alpha is 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
