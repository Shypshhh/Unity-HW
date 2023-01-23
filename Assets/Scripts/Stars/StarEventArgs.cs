using System;

namespace Assets.Scripts.Stars
{
    /// <summary>
    /// Contains arguments for the star event.
    /// </summary>
    public class StarEventArgs : EventArgs
    {
        public Star Star { get; set; }
    }
}
