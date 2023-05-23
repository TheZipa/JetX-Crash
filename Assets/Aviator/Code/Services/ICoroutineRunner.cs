using System.Collections;
using UnityEngine;

namespace Aviator.Code.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}