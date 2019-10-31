using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : Enemy
{
    public Transform m_rocket;  // 子弹Prefab
    protected float m_fireTimer = 0.5f;  // 射击计时器
    protected Transform m_player;  // 主角
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
//    void Update()
//    {
//        // 前进
//        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
//    }

    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;
        if (m_fireTimer <= 0)
        {
            m_fireTimer = 0.5f;
            if (m_player != null)
            {
                // 使用向量减法获取朝向主角位置的方向（目标位置 - 自身位置）
                Vector3 relativePos = m_player.position - transform.position;
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relativePos));
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player");  // 查找主角
                if (obj != null)
                {
                    m_player = obj.transform;
                }
            }
        }
        // 前进（负 Z 方向）
        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
