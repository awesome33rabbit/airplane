using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;
    public float m_life = 3;

    protected Transform m_transform;

    public AudioClip m_shootClip;  // 声音文件
    protected AudioSource m_audio;  // 声音源
    public Transform m_explosionFX;  // 爆炸特效
    
    // 子弹 Prefab
    public Transform m_rocket;
    
    // 发射子弹计时器
    float m_rocketTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();  // 添加代码获取声音源文件
    }

    // Update is called once per frame
    void Update()
    {
        //纵向移动距离
        float movev = 0;

        //水平移动距离
        float moveh = 0;

        //按上键
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movev += m_speed * Time.deltaTime;
        }

        // 按下键
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movev -= m_speed * Time.deltaTime;
        }

        // 按左键
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveh -= m_speed * Time.deltaTime;
        }

        // 按右键
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveh += m_speed * Time.deltaTime;
        }

        //移动
        this.m_transform.Translate(new Vector3(moveh, 0, movev));

        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            // 按空格或鼠标左键发射子弹
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
                
                // 添加代码，播放一次射击声音
                m_audio.PlayOneShot(m_shootClip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerRocket") // 如果与主角子弹以外的碰撞体相撞
        {
            m_life -= 1;
            if (m_life <= 0)
            {
                // 添加代码，当生命为 0 后，播放爆炸特效
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
    
}
