using System.Collections.Generic;
using System.Linq;

//using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startRotation;
    private Vector2 lastTapPosition;
    public Transform topTransforms;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;
    public List<Stage> allStages = new List<Stage>();
    private List<GameObject> spawnedLevels = new List<GameObject>();
    public float helixDistance;

    private void Awake()
    {
      startRotation = transform.localEulerAngles; 
    //   helixDistance = topTransforms.localPosition.y - (goalTransform.localPosition.y + 1f);  
    helixDistance = topTransforms.localPosition.y - goalTransform.localPosition.y;
      LoadStage(0);
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
        Stage stage = allStages[Mathf.Clamp(stageNumber,0,allStages.Count-1)];
        if (stage == null)
        {
            Debug.Log("No stages");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;
        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance/stage.levels.Count;
        float spawnPosY = topTransforms.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefab,transform);
            level.transform.localPosition = new Vector3(0,spawnPosY, 0);
            spawnedLevels.Add(level);

            int partsToDisble = 12-stage.levels[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();
            while (disabledParts.Count<partsToDisble)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }

            List<GameObject> leftParts = new List<GameObject>();
            
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            List<GameObject> deathparts = new List<GameObject>();
            while (deathparts.Count<stage.levels[i].deathPartCount)
            {
                GameObject randomPart = leftParts[Random.Range(0,leftParts.Count)];
                if (!deathparts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathparts.Add(randomPart);
                }
            }
        }
    }
}
