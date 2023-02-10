using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    LevelSection newestGround;

    List<LevelSection> groundPieces = new List<LevelSection>();

    [SerializeField] List<GameObject> levelSections = new List<GameObject>();

    [SerializeField] Transform firewall;

    [SerializeField] float nextGroundDistance;

    float safeDist = 0.2f;


    private void Start()
    {
        if(levelSections.Count < 0)
        {
            Debug.LogError("No level sections provided in Level Generator");
        }
        findCurrentGround();
        newestGround = groundPieces[groundPieces.Count - 1];    
    }


    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            checkIfNextGroundNeeded();
            cleanUpLevelBehind();
        }
    }


    private void findCurrentGround()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            groundPieces.Add(transform.GetChild(i).GetComponent<LevelSection>());
        }
    }



    private void checkIfNextGroundNeeded()
    {
        if (newestGround.GetRightBorder().x <= nextGroundDistance)
        {
            addNewGroundPiece();
        }
    }


    private void addNewGroundPiece()
    {
        //calculate Position of new piece
        Vector3 positionOfNewGround = newestGround.GetRightBorder();
        positionOfNewGround.x -= safeDist;
        //instantiate piece and update references
        GameObject ground = (GameObject)Instantiate(GetNextSection(), positionOfNewGround, Quaternion.identity, transform);
        LevelSection groundPiece = ground.GetComponent<LevelSection>();
        newestGround = groundPiece;
        groundPieces.Add(newestGround);
        //groundPiece.AdjustPosByWidth();

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
            if (groundPieces[1].GetRightBorder().x / 2 < firewall.position.x)
            {
                Destroy(groundPieces[0].gameObject);
                groundPieces.RemoveAt(0);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Vector3 levelPos = transform.position;
        levelPos.x = nextGroundDistance;
        Gizmos.DrawWireSphere(levelPos, 0.3f);
    }
}
