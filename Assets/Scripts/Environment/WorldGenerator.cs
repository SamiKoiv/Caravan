using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private float sizeX = 1;
    [SerializeField] private float sizeY = 1;
    [SerializeField] private float spaceBetweenPoints = 1;
    [SerializeField, Range(0.0f, 0.5f)] private float positionNoise = 0;
    [SerializeField] private float worldTop = 0;
    [SerializeField] private float worldBottom = 0;
    [SerializeField] private int topPoints = 0;
    [SerializeField] private int bottomPoints = 0;

    WorldPoint[,] points;
    Vector3 offset;

    public bool CanGenerate
    {
        get =>
            sizeX > 0
            && sizeY > 0
            && spaceBetweenPoints > 0;
    }

    private int PointsOnX => (int)(sizeX / spaceBetweenPoints + 1);
    private int PointsOnY => (int)(sizeY / spaceBetweenPoints + 1);

    private void OnDrawGizmos()
    {
        if (!CanGenerate) return;

        offset = new Vector3(-sizeX / 2, 0, -sizeY / 2);
        points = new WorldPoint[PointsOnX, PointsOnY];

        DrawDebugRectangle();
        DrawDebugSpace();
        DrawHorizontalMap();
        DrawHeightMap();
        DrawWireFrame();
        DrawMesh();
    }

    private void DrawDebugRectangle()
    {
        Gizmos.color = Color.green;

        var corner_A = new Vector3(-sizeX / 2, 0, -sizeY / 2);
        var corner_B = new Vector3(sizeX / 2, 0, -sizeY / 2);
        var corner_C = new Vector3(sizeX / 2, 0, sizeY / 2);
        var corner_D = new Vector3(-sizeX / 2, 0, sizeY / 2);

        Gizmos.DrawLine(corner_A, corner_B);
        Gizmos.DrawLine(corner_B, corner_C);
        Gizmos.DrawLine(corner_C, corner_D);
        Gizmos.DrawLine(corner_D, corner_A);
    }

    private void DrawDebugSpace()
    {
        Gizmos.color = Color.white;

        var position = new Vector3(0, (worldTop + worldBottom) * 0.5f, 0);

        var size = new Vector3(
            sizeX,
            worldTop - worldBottom,
            sizeY);

        Gizmos.DrawWireCube(position, size);
    }

    private void DrawHorizontalMap()
    {
        Gizmos.color = Color.green;
        var size = new Vector3(spaceBetweenPoints * 0.5f, 0.01f, spaceBetweenPoints * 0.5f);

        for (int y = 0; y < PointsOnY; y++)
        {
            for (int x = 0; x < PointsOnX; x++)
            {
                var canNoise =
                    positionNoise > 0
                    && x > 0
                    && x < PointsOnX - 1
                    && y > 0
                    && y < PointsOnY - 1;

                var noise =
                    canNoise
                    ? new Vector3(Random.Range(0, positionNoise), 0, Random.Range(0, positionNoise))
                    : Vector3.zero;

                var position =
                    new Vector3(x * spaceBetweenPoints, 0, y * spaceBetweenPoints)
                    + offset
                    + noise;

                var point = new WorldPoint(position);
                points[x, y] = point;

                Gizmos.DrawCube(
                    point.Position,
                    size);
            }
        }
    }

    private void SetTopsAndBottoms()
    {
        if (topPoints <= 0 && bottomPoints <= 0) return;

        for (int i = 0; i < topPoints; i++)
        {

        }

        for (int i = 0; i < bottomPoints; i++)
        {

        }
    }

    private void DrawHeightMap()
    {
        Gizmos.color = Color.white;

        for (int y = 0; y < PointsOnY; y++)
        {
            for (int x = 0; x < PointsOnX; x++)
            {
                var point = points[x, y];
                var heightIncrement = Vector3.up * Random.Range(worldBottom, worldTop);
                points[x, y].Position += heightIncrement;
                var size = spaceBetweenPoints * 0.2f;

                switch (point.PositionType)
                {
                    case WorldPoint.PositionTypeEnum.Normal:
                        Gizmos.color = Color.white;
                        break;

                    case WorldPoint.PositionTypeEnum.Top:
                        Gizmos.color = Color.red;
                        break;

                    case WorldPoint.PositionTypeEnum.Bottom:
                        Gizmos.color = Color.blue;
                        break;

                }

                Gizmos.DrawSphere(
                    point.Position,
                    size);

            }
        }

    }

    private void DrawWireFrame()
    {
        Gizmos.color = Color.white;

        //Leave out the outmost points, they get handled in previous round.
        for (int y = 0; y < PointsOnY - 1; y++)
        {
            for (int x = 0; x < PointsOnX - 1; x++)
            {
                var a = points[x, y].Position;           //Down left
                var b = points[x, y + 1].Position;       //Up left
                var c = points[x + 1, y + 1].Position;   //Up right
                var d = points[x + 1, y].Position;       //Down right

                //First triangle
                Gizmos.DrawLine(a, b);
                Gizmos.DrawLine(b, c);
                Gizmos.DrawLine(c, a);

                //Second triangle
                Gizmos.DrawLine(a, c);
                Gizmos.DrawLine(c, d);
                Gizmos.DrawLine(d, a);
            }
        }

    }

    private void DrawMesh()
    {
        var triangles =
            (PointsOnX - 1)
            * (PointsOnY - 1)
            * 6;

    }
}
