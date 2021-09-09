namespace Infastracture
{
    public interface IWaitService
    {
        #region Methods

        IAwaiter WaitFor(float delay);

        #endregion
    }
}