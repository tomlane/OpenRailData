namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public interface ITrainDescriberDatabase
    {
        ITrainDescriberContext DbContext { get; set; }
        ITrainDescriberContext BuildContext();
    }
}
