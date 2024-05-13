using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<Animator>()
            .FromComponentInChildren()
            .AsTransient()
            .WhenInjectedInto<PlayerAnimation>();
    }
}
