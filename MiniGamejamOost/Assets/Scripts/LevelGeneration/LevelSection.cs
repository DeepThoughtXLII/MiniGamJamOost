using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSection : MonoBehaviour
{

    [SerializeField] Transform startGround;
    [SerializeField] Transform endGround;

    BoxCollider2D startColl;
    BoxCollider2D endColl;

    private void Start()
    {
        if(startGround == null || endGround == null)
        {
            Debug.LogError("Level section ground not defined");
        }
        else
        {
            startColl = startGround.GetComponent<BoxCollider2D>();
            endColl = endGround.GetComponent<BoxCollider2D>();
            //AdjustPosByWidth();
        }
    }


    //adjust the position of the section transform to the middle of the section
    public void AdjustPosByWidth()
    {
        Debug.Log(startGround + " " + endGround + " " + startColl + " " + endColl);
            Vector3 pos = transform.position;
            float startX = startGround.position.x - startColl.size.x;
            float endX = endGround.position.x + endColl.size.x;
            float widthOfSection = endX - startX;
            pos.x = startX + widthOfSection/2;
            transform.position = pos;
    }

    public Vector3 GetLeftBorder()
    {
        Vector3 pos = transform.position;
        pos.x = startGround.position.x - startColl.size.x;
        return pos;
        //Vector3 pos = transform.position;
        //pos.x = pos.x - GroundPiece.localScale.x / 2;
        //return pos;
    }

    public Vector3 GetRightBorder()
    {
        Vector3 pos = transform.position;
        pos.x = endGround.position.x + endColl.size.x;
        return pos;
        //Vector3 pos = transform.position;
        //pos.x = pos.x + GroundPiece.localScale.x / 2;
        //return pos;
    }





    /*
    [SerializeField] GameObject LeftCornerPiece;
    [SerializeField] GameObject MiddlePiece;
    [SerializeField] GameObject RightCornerPiece;


    [SerializeField] int width = 1;
    [SerializeField] float TileSize = 1;


    public void SetWidth(int width)
    {
        if(width > 1)
        {
            for(int i = 0; i < width; i++)
            {
                GameObject newMidPiece = Instantiate(MiddlePiece, transform);
                Vector3 pos = MiddlePiece.transform.position;
                pos.x += TileSize * i;
                newMidPiece.transform.position = pos;
            }
            //LeftCornerPiece.transform.position = Get
        }
    }


    //return width in units
    public float GetWidth()
    {
        return (width + 2) * TileSize; //width + 2 because teh corner pieces arent included in the width value
    }

    public Vector3 GetLeftBorder()
    {
        Vector3 pos = LeftCornerPiece.transform.position;
        pos.x = pos.x - LeftCornerPiece.transform.localScale.x / 2;
        return pos;
    }

    public Vector3 GetRightBorder()
    {
        Vector3 pos = RightCornerPiece.transform.position;
        pos.x = pos.x + RightCornerPiece.transform.localScale.x / 2;
        return pos;
    }

    */

}
