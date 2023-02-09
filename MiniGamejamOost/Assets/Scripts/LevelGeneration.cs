using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    [SerializeField] GameObject GroundPrefab;
    [SerializeField] GameObject PlatformPrefab;

    [SerializeField] Transform playerPos;

    [SerializeField] float currentBorderX;

    [SerializeField] Transform newestGround;

    [SerializeField] List<Transform> groundPieces = new List<Transform>();

    Camera _camera;

    [SerializeField] Transform firewall;


    private void Start()
    {
        findCurrentGround();
        currentBorderX = GetBorder(groundPieces[groundPieces.Count-1]); //ground thats furthest away
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
            groundPieces.Add(transform.GetChild(i));
        }
    }

    private void checkIfLeftScreen()
    {
        if (currentBorderX <= playerPos.position.x)
        {
            addNewGroundPiece();
        }
    }

    private void addNewGroundPiece()
    {
        Vector3 positionOfNewGround = newestGround.position;
        positionOfNewGround.x += newestGround.localScale.x/2;
        GameObject ground = (GameObject)Instantiate(GroundPrefab, positionOfNewGround, Quaternion.identity, transform);
        newestGround = ground.transform;
        currentBorderX = GetBorder(newestGround);
        groundPieces.Add(newestGround);
    }

    private float GetBorder(Transform ground)
    {
        return ground.position.x - ground.localScale.x / 2;
    }

    private void cleanUpLevelBehind()
    {
        if (groundPieces.Count > 0)
        {
            if (groundPieces[0].position.x + groundPieces[0].localScale.x / 2 < firewall.position.x)
            {
                Destroy(groundPieces[0].gameObject);
                groundPieces.RemoveAt(0);
            }
        }
        //float camWidth = _camera.aspect * _camera.he
        //if (groundPieces[0].position.x < _camera.)
    }
}
