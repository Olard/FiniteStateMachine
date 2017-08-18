﻿using System;

namespace StateMachine.Fluent.Api
{
    interface GlobalTransitionFluent<STATE, TRIGGER>
    {
        GlobalTransitionBuilderFluent<STATE, TRIGGER> On(TRIGGER trigger);

        GlobalTransitionBuilderFluent<STATE, TRIGGER> If(Func<bool> condition);
    }
}