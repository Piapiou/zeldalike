using UnityEngine;
using System.Collections;

public class ArrowGeneratorController : MonoBehaviour {

    public GameObject arrowPrefab;
    public float generationDelay;
    public float generationTimeOffset;
    public int direction;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerateArrow", generationTimeOffset, generationDelay);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void GenerateArrow()
    {

        GameObject arrow = GameObject.Instantiate(arrowPrefab);
        arrow.GetComponent<arrowController>().direction = direction;
        switch (direction)
        {
            case 0:
                arrow.transform.position = new Vector2(transform.position.x -0.5f, transform.position.y+ 1.0f + 0.5f);
                break;
            case 1:
                arrow.transform.position = new Vector2(transform.position.x - 0.5f + 1.0f, transform.position.y + 0.5f);
                break;
            case 2:
                arrow.transform.position = new Vector2(transform.position.x- 0.5f, transform.position.y - 1.0f + 0.5f);
                break;
            case 3:
                arrow.transform.position = new Vector2(transform.position.x -0.5f - 1.0f, transform.position.y + 0.5f);
                break;
            default:
                break;
        }
    }
}
