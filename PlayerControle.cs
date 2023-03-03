using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    //Установка компонента для твердых тел
    private Rigidbody2D rb;

    //Параметры движения
    public float speed = 5f;
    public float jumpForce = 6f;
    private float movement;
    
    //Параметр поворота персонажа
    private bool facingRight = false;

    //Параметры Системы Прыжка  1)Он на земле? 2)Позиция ног персонажа 3)радиус чекера у ног 4)Что является землей (Слои)
    private bool isGrounded;   
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        //Получаем компонент твердое тело
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Берем направление по Х
        movement = Input.GetAxis("Horizontal");
        //Задаем движение игрока
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        //Система Поворота игрока
        if(facingRight == true && movement < 0 )
        {
            Flip();

        }else if(facingRight == false && movement > 0)
        {
            Flip();
        }
        
    }

    void Update()
    {
    //Система прыжка
        //Проверяет на земле ли игрок путем пложных вычеслений
        isGrounded = Physics2D.OverlapCircle(feetPos.position , checkRadius , whatIsGround);
        //Если Он на земле и Нажат Пробел
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            //Задает прыжок игроку
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    //Функция Поворота Игрока
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f , 180 , 0f);
    }

}