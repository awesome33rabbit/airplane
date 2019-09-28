using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_speed = 1;  // 速度
    public int m_life = 10;  // 生命
    protected float m_rotSpeed;  // 旋转速度
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }
    
    // 注意，为了将来扩展功能，UpdateMove 使一个虚函数
    protected virtual void UpdateMove()
    {
        // 左右移动
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        // 前进（向 -Z 方向）
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }
}
