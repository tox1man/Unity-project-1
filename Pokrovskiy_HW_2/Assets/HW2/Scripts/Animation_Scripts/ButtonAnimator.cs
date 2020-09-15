using UnityEngine;


public class ButtonAnimator : MonoBehaviour
{
    private static Animator _buttonAnimator;

    private void Start()
    {
        _buttonAnimator = GetComponent<Animator>();
    }

    public static void AnimateButton()
    {
        _buttonAnimator.SetBool("isPressed", true);
    }
}
