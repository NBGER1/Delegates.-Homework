namespace UI
{
    public interface IUIManager
    {
        void SetTotalHealthText<T>(T value);
        void SetHealthText<T>(T value);
        void SetTotalManaText<T>(T value);
        void SetManaText<T>(T value);
    }
}