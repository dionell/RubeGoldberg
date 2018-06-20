using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    public Animator anim;

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hands")
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        anim.SetBool("isPressed", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
