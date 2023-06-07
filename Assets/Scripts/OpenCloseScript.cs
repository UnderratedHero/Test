using UnityEngine;

public class OpenCloseScript : MonoBehaviour
{
    private bool isOpen = false;
    private int count = 0;
    private SpriteRenderer sprite;

    [SerializeField] private float speed = 2.0f;

    public GameObject ScriptObject;
    public Transform targetVector1;
    public Transform targetVector2;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (count == 1 && isOpen == false)
        {
            MoveLeft();

            CheckSunRoof1();
        }

        if (count == 0 && isOpen == true)
        {
            MoveRight();

            CheckSunRoof2();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        count++;
        sprite.color = Color.red;
        Debug.Log("Enter the collision");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        count--;
        isOpen = true;
        sprite.color = Color.white;
        Debug.Log("Exit the collision");
    }

    private void CheckSunRoof1()
    {
        if (ScriptObject.transform.position == targetVector1.position)
        {
            isOpen = true;
            Debug.Log("Open ends");
        }
    }

    private void CheckSunRoof2()
    {
        if (ScriptObject.transform.position == targetVector2.position)
        {
            isOpen = false;
            Debug.Log("Close ends");
        }
    }

    public void MoveLeft()
    {
        ScriptObject.transform.position = Vector3.MoveTowards(ScriptObject.transform.position, targetVector1.position, speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        ScriptObject.transform.position = Vector3.MoveTowards(ScriptObject.transform.position, targetVector2.position, speed * Time.deltaTime);
    }
}
