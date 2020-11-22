using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////
    ////////////// ★あり…「課題：キューブの接触時に効果音をつけよう」の加筆部分 //////////////
    ////////////////////////////////////////////////////////////////////////////////////////////

    // キューブの移動速度
    private float speed = -12;
    // 消滅位置
    private float deadLine = -10;
    // ★ブロックの衝突音
    private AudioSource blockAudio;

    // Start is called before the first frame update
    void Start()
    {
        // ★ブロックのAudioSourceを取得する
        blockAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // ★ブロックが他オブジェクトと衝突したときの処理
    void OnCollisionEnter2D(Collision2D other)
    {
        // ★Unityちゃん（Playerタグ）ではないオブジェクトに衝突したとき効果音を鳴らす
        if (other.gameObject.tag != "Player") { blockAudio.Play(0); }
    }
}
