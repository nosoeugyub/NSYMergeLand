using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���׸� State
public interface IState<T>
{
    void Enter(T context);
    void Excute(T context);
    void Exit(T Context);
}
