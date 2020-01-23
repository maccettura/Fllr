namespace Fllr.Application.Interfaces
{
    public interface IBaseRequest
    {
        int Width { get; }

        int Height { get; }

        string Extension { get; }
    }
}