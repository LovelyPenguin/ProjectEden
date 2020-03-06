using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Acidfall : MonoBehaviour
{
    public GameObject Acidbullect;
    public float Acid_Speed;

    // Start is called before the first frame update
    void Awake()
    {
        st();

    }
    void st()
    {
        if (!gameObject.activeSelf)
            return;
        
        

        InvokeRepeating("Down", 1.334f, 1.5f);
    }

    void Down()
    {
        GameObject bullect = Instantiate(Acidbullect, new Vector2(transform.position.x -0.0054f, transform.position.y - 1.06f), transform.rotation);
        Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * Acid_Speed, ForceMode2D.Impulse);
    }


}
