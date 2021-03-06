﻿/* Copyright 2015 Brock Reeve
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Linq;

namespace Pickaxe.Sdk
{
    public class SelectStatement : AstNode
    {
        public SelectArg[] Args
        {
            get
            {
                var list = Children.ToList();
                list.Remove(From);
                list.Remove(Where);
                return list.Cast<SelectArg>().ToArray();
            }
        }

        public FromStatement From
        {
            get { return Children.Where(x => x.GetType() == typeof(FromStatement)).Cast<FromStatement>().SingleOrDefault(); }
        }

        public WhereStatement Where
        {
            get { return Children.Where(x => x.GetType() == typeof(WhereStatement)).Cast<WhereStatement>().SingleOrDefault(); }
        }

        public override void Accept(IAstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
