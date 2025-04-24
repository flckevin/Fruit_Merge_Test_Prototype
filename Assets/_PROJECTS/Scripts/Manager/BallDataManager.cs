using Quocanh.pattern;
public class BallDataManager : QuocAnhSingleton<BallDataManager>
{
    public BallBehaviour[] BallBehaviourPrefabData;
    public int maxBall => BallBehaviourPrefabData.Length - 1;
}
