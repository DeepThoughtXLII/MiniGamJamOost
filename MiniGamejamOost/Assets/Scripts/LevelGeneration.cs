using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    [SerializeField] GameObject PlatformPrefab;

    [SerializeField] Transform playerPos;

    [SerializeField] LevelSection newestGround;

    List<LevelSection> groundPieces = new List<LevelSection>();

    [SerializeField] List<GameObject> levelSections = new List<GameObject>();

    [SerializeField] Vector2Int widthRangeOfGroundTiles = new Vector2Int(1, 3);

    Camera _camera;

    [SerializeField] Transform firewall;


    private void Start()
    {
        if(levelSections.Count < 0)
        {
            Debug.LogError("No level sections provided in Level Generator");
        }
        findCurrentGround();
        newestGround = groundPieces[groundPieces.Count - 1];    
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfLeftScreen();
        cleanUpLevelBehind();
    }


    private void findCurrentGround()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            groundPieces.Add(transform.GetChild(i).GetComponent<LevelSection>());
        }
    }

    private void checkIfLeftScreen()
    {
        if (playerPos.position.x >= newestGround.GetLeftBorder().x)
        {
            addNewGroundPiece();
        }
    }

    private void addNewGroundPiece()
    {
        //calculate Position of new piece
        Vector3 positionOfNewGround = newestGround.GetRightBorder();

        //instantiate piece and update references
        GameObject ground = (GameObject)Instantiate(GetNextSection(), positionOfNewGround, Quaternion.identity, transform);
        LevelSection groundPiece = ground.GetComponent<LevelSection>();
        newestGround = groundPiece;
        groundPieces.Add(newestGround);
        groundPiece.AdjustPosByWidth();

    }

    private GameObject GetNextSection()
    {
        int index = Random.Range(0, levelSections.Count);
        return levelSections[index];
    }


    private void cleanUpLevelBehind()
    {
        if (groundPieces.Count > 0)
        {
            if (groundPieces[0].GetRightBorder().x / 2 < firewall.position.x)
            {
                Destroy(groundPieces[0].gameObject);
                groundPieces.RemoveAt(0);
            }
        }
        //float camWidth = _camera.aspect * _camera.he
        //if (groundPieces[0].position.x < _camera.)
    }
}
