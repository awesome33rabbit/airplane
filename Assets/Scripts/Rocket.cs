using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_speed = 10;
    public float m_power = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnBecameInvisible()
    {
        if (this.enabled) // 通过判断是否处于激活状态防止重复删除
            Destroy(this.gameObject); // 当离开屏幕后销毁
    }

    // Update is called once per frame
    void Update()
    {
        // 向前（Z方向移动）
        transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }
}