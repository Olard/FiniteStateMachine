﻿// *************************************************************************** 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>
// ***************************************************************************

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using StateMachine.Events;

namespace StateMachine
{
    [PublicAPI]
    public class StateModel<TS, TT, TD>
    {
        public event Action<StateChangeArgs<TS, TT, TD>> Entered;
        public event Action<StateChangeArgs<TS, TT, TD>> Exited;
        public event Action<UpdateArgs<TS, TT, TD>> Updated;

        public TS Identifier { get; private set; }
        public bool EndState { get; set; }
        public bool ClearStack { get; set; }

        public Dictionary<TS, Transition<TS, TT, TD>> Transitions { get; } =
            new Dictionary<TS, Transition<TS, TT, TD>>();

        public StateModel(TS identifier)
        {
            Identifier = identifier;
        }

        /// <exception cref="FsmBuilderException">When the handler is null</exception>
        public void AddEnteredHandler(Action<StateChangeArgs<TS, TT, TD>> e)
        {
            if (e == null) throw FsmBuilderException.HandlerCannotBeNull();
            Entered += e;
        }

        public void RaiseEntered(StateChangeArgs<TS, TT, TD> e) => Entered?.Invoke(e);

        /// <exception cref="FsmBuilderException">When the handler is null</exception>
        public void AddExitedHandler(Action<StateChangeArgs<TS, TT, TD>> e)
        {
            if (e == null) throw FsmBuilderException.HandlerCannotBeNull();
            Exited += e;
        }

        public void RaiseExited(StateChangeArgs<TS, TT, TD> e) => Exited?.Invoke(e);

        /// <exception cref="FsmBuilderException">When the handler is null</exception>
        public void AddUpdatedHandler(Action<UpdateArgs<TS, TT, TD>> e)
        {
            if (e == null) throw FsmBuilderException.HandlerCannotBeNull();
            Updated += e;
        }

        public void RaiseUpdated(UpdateArgs<TS, TT, TD> data) => Updated?.Invoke(data);
    }
}