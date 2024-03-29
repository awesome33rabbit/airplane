﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/EnemySpawn")]
public class EnemySpawn : MonoBehaviour
{
    public Transform m_enemyPrefab;  // 敌人的Prefab
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());  // 执行协程函数
    }

    IEnumerator SpawnEnemy()   // 使用协程创建敌人
    {
        while (true)  // 循环创建敌人
        {
            yield return new WaitForSeconds(Random.Range(5, 15));  // 随机等待 5-15 秒
            Instantiate(m_enemyPrefab, transform.position, Quaternion.identity);  // 生成敌人实例
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
