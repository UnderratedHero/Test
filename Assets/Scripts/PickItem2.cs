using UnityEngine;

public class PickItem2 : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CircleCollider2D circleObj;
    private Rigidbody2D itemRb;
    private bool inTriggerZone = false;

    public Transform Parent;

    private void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(KeyCode.LeftShift))
        {
            GiveCircleParent(circleObj);

            ChangeColoreRed();
        }

        if (inTriggerZone && Input.GetKeyUp(KeyCode.LeftShift))
        {

            DropCircleParent(circleObj);

            ChangeColoreWhite();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            sprite = GetComponentInChildren<SpriteRenderer>();

            circleObj = circle;

            inTriggerZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
        {
            sprite = GetComponentInChildren<SpriteRenderer>();

            inTriggerZone = false;

            ChangeColoreWhite();
        }
    }

    private void ChangeColoreRed()
    {
        sprite.color = Color.red;
    }

    private void ChangeColoreWhite()
    {
        sprite.color = Color.white;
    }

    private void GiveCircleParent(CircleCollider2D circle)
    {
        circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        circle.GetComponentInChildren<SpriteRenderer>().enabled = false;

        circle.transform.SetParent(Parent);
    }

    private void DropCircleParent(CircleCollider2D circle)
    {
        circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        circle.GetComponentInChildren<SpriteRenderer>().enabled = true;

        circle.transform.SetParent(null);
    }
}
