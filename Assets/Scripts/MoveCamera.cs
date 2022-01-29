using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] Transform target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagNames.PLAYER_TAG)
        {
            cam.transform.SetParent(target);
            cam.transform.localPosition = new Vector3(0, 0, -10);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagNames.PLAYER_TAG)
        {
            cam.transform.SetParent(player);
            cam.transform.localPosition = new Vector3(0, 0, -10);
        }
    }
}
