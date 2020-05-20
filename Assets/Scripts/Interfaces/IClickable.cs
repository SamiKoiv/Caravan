
namespace ProjectCaravan.Interfaces
{
    public interface IClickable
    {
        bool Highlight { get; set; }
        void LeftClick();
        void RightClick();
    }
}
