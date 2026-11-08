using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPosition;
    private Vector2 lastTapPosition;
    public Transform topTransforms;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;
    public List<Stage> allStages = new List<Stage>();
    private List<GameObject> spawnedLevels = new List<GameObject>();
    public float helixDistance;

    private void Awake()
    {
      startPosition = transform.localEulerAngles; 
      helixDistance = topTransforms.localPosition.y - (goalTransform.localPosition.y + 1f);  
    //   LoadStage(0);
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetMouseButton(0))
    {
        Vector2 currentTapPosition = Input.mousePosition;

        if (lastTapPosition == Vector2.zero)
        {
            lastTapPosition = currentTapPosition;
        }

        float distance = lastTapPosition.x - currentTapPosition.x;
        lastTapPosition = currentTapPosition;
    }
}
public void LoadStage(int stageNumber)
    {
        
    }
}
