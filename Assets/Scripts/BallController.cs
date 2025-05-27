using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Button bounceButton;
    private Animator ballAnimator = null;

    IEnumerator Start()
    {
        ballAnimator = GetComponent<Animator>();
        yield return new WaitUntil(() => ballAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        bounceButton.interactable = true;
    }

    public void OnClickButton()
    {
        StartCoroutine(DoBounce());
    }

    private IEnumerator DoBounce()
    {
        bounceButton.interactable = false;
        ballAnimator.Play("Bounce");

        yield return new WaitForEndOfFrame();

        yield return new WaitUntil(() => ballAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));

        bounceButton.interactable = true;
    }
}
