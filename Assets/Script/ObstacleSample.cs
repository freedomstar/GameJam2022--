using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSample : MonoBehaviour
{
    public GameMode Mode;
    public GameObject Obstacle;
    public int MaxCount = 2;
    public int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Count < MaxCount)
        {
            if (Mode.RayObject == gameObject)
            {
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z));
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Mode.pickObject = GameObject.Instantiate(Obstacle, mousePos+new Vector3(0.5f,0.5f,transform.position.z), Quaternion.identity);
                Mode.pickObject.GetComponent<Obstacle>().Sample = this;
                Mode.pickObject.GetComponent<Obstacle>().Mode = Mode;
                Mode.State = GameMode.GameState.Place;
                Mode.Obstacles.Add(Mode.pickObject);
                Count++;
            }
        }
    }
}
