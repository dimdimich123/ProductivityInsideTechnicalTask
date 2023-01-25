using Infrastructure.CommonLogic;

namespace GameCore.Buildings
{
    public interface IBuilding
    {
        public Building AcceptVisitor(IVisitor visitor);
    }
}