using System;
using System.Collections.Generic;
using System.Text;
using Base.Static.Enumerate;

namespace Crm.Core.Enumerations
{
    public class ActorType : Enumeration
    {
        public static ActorType Application = new ActorType(1, "Application");
        public static ActorType User = new ActorType(2, "User");
        public ActorType(int id, string name) : base(id, name)
        {

        }
    }
}
