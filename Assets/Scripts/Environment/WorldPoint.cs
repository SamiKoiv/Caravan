using UnityEngine;

public struct WorldPoint
{
    public Vector3 Position;
    public PositionTypeEnum PositionType;

    public WorldPoint(Vector3 position)
    {
        this.Position = position;
        this.PositionType = PositionTypeEnum.Normal;
    }

    public enum PositionTypeEnum
    {
        Normal,
        Top,
        Bottom
    }
}
