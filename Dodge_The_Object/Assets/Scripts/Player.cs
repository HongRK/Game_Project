using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Transform Player_move;  //플레이어의 위치값
    public GameObject effect;
    private float Speed;
    private int hp;
    private int initHp;

    private Vector3 Respawn;


    private void Awake()
    {
        Player_move = GameObject.FindGameObjectWithTag("Player").transform;
        Speed = 10f;
        initHp = 10;
        hp = initHp;

        Respawn = new Vector3(0, -3, 0);
    }
    void Update()
    {
        Move();
    }
    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        /////////////////////////Y값에 대한 /////////////////////
        float size = Camera.main.orthographicSize;
        float offset = 0.9f;
        if (Player_move.position.y >= size - offset)
        {
            Player_move.position = new Vector3(Player_move.position.x, size - offset, 0);
        }
        if (Player_move.position.y <= -(size - offset))
        {
            Player_move.position = new Vector3(Player_move.position.x, -(size - offset), 0);
        }
        /////////////////////////////////////////////////////
        float ScreenRation = (float)Screen.width / (float)Screen.height;
        float Wsize = Camera.main.orthographicSize * ScreenRation; // 가로 사이즈

        if (Player_move.position.x >= Wsize - offset)
        {
            Player_move.position = new Vector3(Wsize - offset, Player_move.position.y, 0);
        }
        if (Player_move.position.x <= -(Wsize - offset))
        {
            Player_move.position = new Vector3(-(Wsize - offset), Player_move.position.y, 0);
        }
        // 매 프레임마다 메소드 호출

        if (Input.GetKey(KeyCode.UpArrow))  // ↑ 방향키를 누를 때
        {
            // Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다.
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            // Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
        }
        if (Input.GetKey(KeyCode.DownArrow))  // ↓ 방향키를 누를 때
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Ojbect"))
            hp--;
        

        if (hp <= 0)
        {
            Instantiate(effect, Player_move.position, Quaternion.identity);
            Player_move.position = Respawn;
            hp = initHp;
         
        }

    }
}
