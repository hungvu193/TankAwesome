using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
  public Transform player;
  private bool touchStart = false;
  public float speed = 5.0f;
  private Vector2 pointA;
  private Vector2 pointB;

  public Transform circle;
  public Transform outerCircle;


  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.transform.position.z));
      circle.transform.position = pointA;
      outerCircle.transform.position = pointA;
      circle.GetComponent<SpriteRenderer>().enabled = true;
      outerCircle.GetComponent<SpriteRenderer>().enabled = true;
    }

    if (Input.GetMouseButton(0))
    {

      pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
      touchStart = true;
    }
    else
    {
      touchStart = false;

    }
  }

  void FixedUpdate()
  {
    if (touchStart)
    {
      Vector2 offset = pointB - pointA;
      Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
      moveTank(direction);
      circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
    }
    else
    {
      circle.GetComponent<SpriteRenderer>().enabled = false;
      outerCircle.GetComponent<SpriteRenderer>().enabled = false;
    }
  }

  void moveTank(Vector2 direction)
  {
    player.Translate(direction * speed * Time.deltaTime);
  }
}
