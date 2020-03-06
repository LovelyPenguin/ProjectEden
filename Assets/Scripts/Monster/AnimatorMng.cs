using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMng : MonoBehaviour
{
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        if (anime == null)
        {
            Debug.LogError(gameObject.name + " Not found Animator");
        }
    }

    public void AnimatorSetBoolTrue(string name)
    {
        anime.SetBool(name, true);
    }

    public void AnimatorSetBoolFalse(string name)
    {
        anime.SetBool(name, false);
    }
}
