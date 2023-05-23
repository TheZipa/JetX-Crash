using Aviator.Code.Core.MultiplierRunner;
using Aviator.Code.Core.Plane;
using Aviator.Code.Core.Timer;
using Aviator.Code.Core.UI;
using UnityEngine;

namespace Aviator.Code.Services.Factories.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreateField();
        FieldText CreateFieldText(Transform parent);
        PlaneView CreatePlaneView(Transform parent);
        ITimer CreateTimer(FieldText fieldText);
        IMultiplierRunner CreateMultiplierRunner(FieldText fieldText);
    }
}