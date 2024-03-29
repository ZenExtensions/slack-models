using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenExtensions.Slack.Models.CompositionObjects
{
    /// <summary>
    /// Composition objects can be used inside of block elements and certain message payload fields. They are simply common JSON object patterns that you'll encounter frequently when building blocks or composing messages.
    /// </summary>
    public abstract record class CompositionObject
    {
        internal abstract void Validate();
    }
}