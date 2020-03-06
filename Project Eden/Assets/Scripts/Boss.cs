using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    Rigidbody2D rigid;
    public Vector2 EnemyPosition;
    public Vector2 EnOrignPos;

    public GameObject BossBullectA;
    public GameObject player;
    public GameObject BloodShield;
    public GameObject Bloodpool;
    public GameObject Bloodsphere;
  

    public float maxDelay;
    public float curShotDelay;
    public float curMoveDelay;
    public float PlayTime;
    public bool delayobject;

    public int patternIndex;
    public int curpatternCount;
    public int maxpatternCount = 6;
    public int a;//이거는 1-2패턴때 사용하는거


    public float VL_PT1_Speed = 3;
    public float VL_PT1_Delay = 1;
    public float VL_PT1_Cooldown;
    public float VL_PT2_Speed = 3;
    public float VL_PT2_Delay = 1;
    public float VL_PT2_Cooldown;

    public float VL_PT3_Speed = 3;
    public float VL_PT3_Cooldown;

    public float VL_PT4_Range;
    public float VL_PT4_Cooldown;
    public float VL_PT5_Bomb_Time = 2;
    public float VL_PT5_Bomb_Range;
    public float VL_PT5_Pud_DurationTime = 10;
    public float VL_PT5_Pud_Range;
    public float VL_PT5_Cooldown;
    public float VL_PT6_Speed = 100;
    public float VL_PT6_Delay;
    public float VL_PT6_Cooldown;
    public float VL_PT7_MinR = 0.5f;
    public float VL_PT7_MaxR;
    public float VL_PT7_Speed;
    public float VL_PT8_Speed;
    public float VL_PT8_Delay;
    public float VL_PT8_Cooldown;
    public List<string> pattern = new List<string>();
    public string patternname;
    public float patternTime;

    void Start()
    {





    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        curpatternCount = 0;
        curShotDelay = 0;
        //등장 모션및 대사들
        maxDelay = 5.0f;
        Debug.Log("등장");
        //Invoke("Think", 5);
        a = 1;
        EnOrignPos = Vector2.zero;

        Debug.Log(EnOrignPos);
        staro();

        pattern.Add("발사1");
        pattern.Add("발사2");
        pattern.Add("발사3");
        pattern.Add("돌진");
        pattern.Add("피웅덩이");
        pattern.Add("피폭발");

    }

    void staro()
    {
        if (!gameObject.activeSelf)
            return;
        rigid = GetComponent<Rigidbody2D>();
        posreturn();

        Invoke("Think", 6f);
        
    }

    void OnEnable()
    {




    }

    void Update()
    {
        PlayTime += Time.deltaTime;     
    }
    



    // Update is called once per frame
    void FixedUpdate()
    {

        //rigid.velocity = new Vector2(nextMove, rigid.velocity.y);




    }

    void pattern1()
    {

        InvokeRepeating("translate", 3f, VL_PT1_Delay);
        Debug.Log("trans 끝");

        posreturn();
        InvokeRepeating("DownFire", 9f, VL_PT1_Delay);
        Debug.Log("보스위치초기화");
        //Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
        //rigid.AddForce(Vector2.down * 1.0f, ForceMode2D.Impulse);
    }

    void Canceltranslate()
    {
        CancelInvoke("translate");
    }

    void CancelDownFire()
    {
        CancelInvoke("DownFire");
    }

    void translate()
    {
        if (a > 5)
        {
            a = 1;
            CancelInvoke("translate");
            posreturn();

        }
        else
        {
            transform.position = new Vector2(6.5f * a - 20f, 0f);
            a += 1;
            Firepro();
            

            Debug.Log("trans 반복중");
        }
    }

    void pattern2()
    {

        InvokeRepeating("translate2", 3f, VL_PT2_Delay);
        Debug.Log("trans 끝");

        posreturn();
        InvokeRepeating("GuidedFire", 9f, VL_PT2_Delay);
        Debug.Log("보스위치초기화");
        //Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
        //rigid.AddForce(Vector2.down * 1.0f, ForceMode2D.Impulse);
    }

    void Canceltranslate2()
    {
        CancelInvoke("translate2");
    }

    void translate2()
    {
        if (a > 5)
        {
            a = 1;
            CancelInvoke("translate2");
            posreturn();

        }
        else
        {
            transform.position = new Vector2(6.5f * a - 20f, 0f);
            a += 1;
            Firepro();
            //Invoke("GuidedFire", 6);

            Debug.Log("trans 반복중");
        }
    }


    void Firepro()
    {
        GameObject bullect = Instantiate(BossBullectA, new Vector2(transform.position.x, transform.position.y - 2.0f), transform.rotation);

        Destroy(bullect, 6);
    }



    void DownFire()
    {
        if (a > 5)
        { a = 1;
            CancelInvoke("DownFire");
        }
        else
        {
            Vector2 fire = new Vector2(6.5f * a - 20f, -2f);
            GameObject bullect = Instantiate(BossBullectA, new Vector3(fire.x, fire.y), transform.rotation);

            Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.down * VL_PT1_Speed, ForceMode2D.Impulse);
            Debug.Log(a);
            a++;
        }
        /*Vector3 dirVec = player.transform.position - transform.position;
        rigid.AddForce(dirVec * 2, ForceMode2D.Impulse);>> 적공격
        rigid.AddForce(Vector2.down*1.0f,ForceMode2d.Impulse);>> 밑으로 내릴경우
        */

    }

    void GuidedFire()
    {
        if (a > 5)
        {
            a = 1;
            CancelInvoke("GuidedFire");
        }
        else
        {
            Vector3 fire = new Vector3(6.5f * a - 20f, -2f);
            GameObject bullect = Instantiate(BossBullectA, new Vector3(fire.x, fire.y), transform.rotation);

            Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
            Vector3 dirVec = new Vector3(player.transform.position.x - fire.x, player.transform.position.y - fire.y + 0.5f);
            rigid.AddForce(dirVec.normalized * VL_PT2_Speed, ForceMode2D.Impulse);
          
        }
    }

    void ConeFire()
    {
        for (int index = -2; index < 3; index++)
        {
            GameObject bullect = Instantiate(BossBullectA, new Vector3(transform.position.x, transform.position.y - 1.0f), transform.rotation);


            Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y + 1.0f);
            Vector2 ranVec = new Vector2(2.0f * index, 2.0f * index);
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized * VL_PT3_Speed, ForceMode2D.Impulse);
        }
    }

    void ReMoveload()
    {
        curMoveDelay += Time.deltaTime;

    }


    void pattern3()
    {
        if (player.transform.position.x < 20)
        {
            transform.position = new Vector2(-13.37f, 2.5f);

            ConeFire();
            Invoke("ConeFire", 0.8f);

        }
        else
        {
            transform.position = new Vector2(13.37f, 2.5f);

            ConeFire();
            Invoke("ConeFire", 0.8f);
        }


    }

    void pattern4()
    {
        int Way;
        Way = Random.Range(1, 3);

        switch (Way)
        {
            case 1:
                Debug.Log("왼쪽에서시작");

                transform.position = new Vector2(-17.6f, -6f);

                Invoke("right", 0.5f);
                Invoke("posreturn", 6f);


                break;
            case 2:
                Debug.Log("오른쪽에서시작");

                transform.position = new Vector2(17.6f, -6f);


                Invoke("left", 0.5f);
                Invoke("posreturn", 6f);


                break;
        }

    }

    void right()
    {
        rigid.AddForce(Vector2.right * VL_PT6_Speed, ForceMode2D.Impulse);

    }

    void left()
    {
        rigid.AddForce(Vector2.left * VL_PT6_Speed, ForceMode2D.Impulse);
    }

    void pattern5()
    {
        Invoke("Bloodsph", 0.5f);
        Invoke("BloodExpl", 2.0f);

    }

    void Bloodsph()
    {
        for (int a = 1; a < 3; a++)
        {
            GameObject Bloodsph = Instantiate(Bloodsphere, new Vector3(-30.0f + 20.0f * a, -8.61f), transform.rotation);

            Destroy(Bloodsph, VL_PT5_Bomb_Time);
        }
    }

    void BloodExpl()
    {

        for (int a = 1; a < 3; a++)
        {
            GameObject Bloodpo = Instantiate(Bloodpool, new Vector3(-30.0f + 20.0f * a, -8.61f), transform.rotation);

            Destroy(Bloodpo, VL_PT5_Pud_DurationTime);
        }
    }

    void pattern6()//피폭발
    {
        GameObject Bloodshield = Instantiate(BloodShield, transform.position, transform.rotation);

        Destroy(Bloodshield, 5);
    }

    void pattern7()//분노
    {
        Vector3 pos = new Vector3(0f, 0f);


        float bullectnumbers = 20;
        for (int index = 1; index <= bullectnumbers; index++)
        {



            Vector3 dirVec = new Vector3(VL_PT7_MinR * Mathf.Cos(Mathf.PI * 2 * index / bullectnumbers), VL_PT7_MinR * Mathf.Sin(Mathf.PI * 2 * index / bullectnumbers));

            pos += dirVec;

            GameObject bullect = Instantiate(BossBullectA, pos, transform.rotation);
            Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();

            //rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);


            Destroy(bullect, 3);
        }

        Invoke("roundFire", 3.0f);
    }

    void roundFire()
    {
        Vector3 pos = new Vector3(0f, 0f);
        float bullectnumbers = 20;
        for (int index = 1; index <= bullectnumbers; index++)
        {



            Vector3 dirVec = new Vector3(VL_PT7_MinR * Mathf.Cos(Mathf.PI * 2 * index / bullectnumbers), VL_PT7_MinR * Mathf.Sin(Mathf.PI * 2 * index / bullectnumbers));

            pos += dirVec;

            GameObject bullect = Instantiate(BossBullectA, pos, transform.rotation);
            Rigidbody2D rigid = bullect.GetComponent<Rigidbody2D>();

            rigid.AddForce(dirVec.normalized * 20, ForceMode2D.Impulse);


            Destroy(bullect, 1.5f);
        }

    }

    void pattern8()
    {
        Invoke("bossup", 1);
        Invoke("bosswait", 1.7f);
        Invoke("bossdownatt", 3f);

        Invoke("posreturn", 7);

    }

    void bossup()
    {
        rigid.velocity = new Vector3(0, 0);
        rigid.AddForce(Vector2.up * 14f, ForceMode2D.Impulse);
    }

    void bosswait()
    {
        rigid.velocity = new Vector3(0, 0);

    }

    void bossdownatt()
    {

        Vector3 dirVec = player.transform.position - transform.position;
        rigid.AddForce(dirVec.normalized * 90f, ForceMode2D.Impulse);
    }

    void Think()
    {
        if (!gameObject.activeSelf)
            return;
       
            if (PlayTime < 90)
            {
                Debug.Log("1페이지");

                patternIndex = Random.Range(0, maxpatternCount);
            }
            else if (curpatternCount < 1)
            {

                Debug.Log("2페이지진입");
                patternname = "분노";
                maxpatternCount++;
                pattern.Add("찍기");
            }
            else
            {
                Debug.Log("2페이지");

                patternIndex = Random.Range(0, maxpatternCount);
            }
            Debug.Log(patternIndex);

        
        patternname = pattern[patternIndex];
        Debug.Log(patternname);
        switch (patternname)
        {
            case "발사1":
                pat1();
                Debug.Log("발사1");
                a = 1;
                pattern.Remove("발사1");
                maxpatternCount--;
                Invoke("addpattern1", 50);
                patternTime += Time.deltaTime;
                break;
            case "발사2":
                pat2();
                Debug.Log("발사2");
                a = 1;
                pattern.Remove("발사2");
                maxpatternCount--;
                Invoke("addpattern2", 50);
                patternTime += Time.deltaTime;
                break;
            case "발사3":
                pat3();
                a = 1;
                pattern.Remove("발사3");
                maxpatternCount--;
                Invoke("addpattern3", 50);
                Debug.Log("발사3");
                patternTime += Time.deltaTime;
                break;
            case "돌진":
                pat4();
                pattern.Remove("돌진");
                maxpatternCount--;
                Invoke("addpattern4", 40);
                Debug.Log("돌진");
                patternTime += Time.deltaTime;
                break;
            case "피웅덩이":
                pat5();
                pattern.Remove("피웅덩이");
                maxpatternCount--;
                Invoke("addpattern5", 50);
                Debug.Log("피웅덩이");
                patternTime += Time.deltaTime;
                break;
            case "피폭발":
                pat6();
                pattern.Remove("피폭발");
                maxpatternCount--;
                Invoke("addpattern6", 40);
                Debug.Log("피폭발");
                patternTime += Time.deltaTime;
                break;
            case "분노":
                curpatternCount++;
                pat7();
                
                Debug.Log("분노");
                patternTime += Time.deltaTime;
                break;

            case "찍기":
                Debug.Log("찍기");
                pattern.Remove("돌진");
                maxpatternCount--;
                Invoke("addpattern8", 40);
                pat8();
                patternTime += Time.deltaTime;
                break;
        }
    }

    void pat1()
    {

        pattern1();

        Invoke("Think", VL_PT1_Cooldown);
    }

    void pat2()
    {

        pattern2();

        Invoke("Think", VL_PT2_Cooldown);
    }

    void pat3()
    {

        pattern3();
        Invoke("posreturn", 2);

        Invoke("Think", VL_PT3_Cooldown);
    }

    void pat4()
    {

        pattern4();

        Invoke("Think", VL_PT6_Cooldown);
    }

    void pat5()
    {
        pattern5();

        Invoke("Think", VL_PT5_Cooldown);
    }

    void pat6()
    {
        pattern6();

        Invoke("Think", 15);
    }

    void pat7()
    {
        pattern7();

        Invoke("Think", 10);
    }

    void pat8()
    {
        pattern5();

        Invoke("pat8_1", 4);

        //벽에 찍기까지
        Invoke("pattern8", 5);

        Invoke("Think", 20);
    }

    void pat8_1()
    {
        int Way;
        Way = Random.Range(1, 3);

        switch (Way)
        {
            case 1:
                Debug.Log("왼쪽에서시작");

                transform.position = new Vector2(-17.6f, -6f);

                Invoke("right", 0.5f);



                break;
            case 2:
                Debug.Log("오른쪽에서시작");

                transform.position = new Vector2(17.6f, -6f);


                Invoke("left", 0.5f);


                break;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }


    }


    void posreturn()
    {
        rigid.velocity = Vector3.zero;
        transform.position = EnOrignPos;
    }


    void addpattern1()
    {
        pattern.Add("발사1");
        maxpatternCount++;
    }

    void addpattern2()
    {
        pattern.Add("발사2");
        maxpatternCount++;
    }

    void addpattern3()
    {
        pattern.Add("발사3");
        maxpatternCount++;
    }

    void addpattern4()
    {
        pattern.Add("돌진");
        maxpatternCount++;
    }

    void addpattern5()
    {
        pattern.Add("피웅덩이");
        maxpatternCount++;
    }

    void addpattern6()
    {
        pattern.Add("피폭발");
        maxpatternCount++;
    }

    void addpattern7()
    {
        
       
    }

    void addpattern8()
    {
        pattern.Add("찍기");
        maxpatternCount++;
    }

}