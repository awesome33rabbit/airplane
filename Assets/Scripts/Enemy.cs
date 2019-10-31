using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_speed = 1;  // 速度
    public float m_life = 10;  // 生命

    protected float m_rotSpeed;  // 旋转速度

    internal Renderer m_renderer;  // 模型渲染组件
    internal bool m_isActiv = false;  // 是否激活
    
    public AudioClip m_shootClip;  // 声音文件
    protected AudioSource m_audio;  // 声音源
    public Transform m_explosionFX;  // 爆炸特效
    
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();  // 获取模型渲染组件
        m_audio = this.GetComponent<AudioSource>();  // 添加代码获取声音源文件
    }

    private void OnBecameVisible()  // Unity 事件函数，当模型进入可视范围
    {
        m_isActiv = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if (m_isActiv && !this.m_renderer.isVisible)  // 如果移动到屏幕外
        {
            Destroy(this.gameObject);  // 自我销毁
        }
    }
    
    // 注意，为了将来扩展功能，UpdateMove 使一个虚函数
    protected virtual void UpdateMove()
    {
        // 左右移动
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        // 前进（向 -Z 方向）
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRocket")
        // 如果撞到主角子弹
        {
            Rocket rocket = other.GetComponent<Rocket>();  // 获得子弹上的Rocket脚本组件
            if (rocket != null)
            {
                m_life -= rocket.m_power;  // 减少生命
                if (m_life <= 0)
                {
                    // 添加代码，当生命为 0 后，播放爆炸特效
                    Instantiate(m_explosionFX, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);  // 自我销毁
                    
                }
            }
        }
        else
        {
            if (other.tag == "Player")  // 如果撞到主角
            {
                m_life = 0;
                Destroy(this.gameObject);  // 自我销毁
            }
        }
    }
}
