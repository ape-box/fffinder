using Engine.Models;
using System.Collections.Generic;

namespace Engine
{
    public interface IFinderEngine
    {
        List<ResultModel> FindMenu(string location, string food);
    }
}