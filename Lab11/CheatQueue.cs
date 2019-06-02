//
//  CheatQueue.cs
//  CheatQueue
//
//  Created by Сорокин Дмитрий on 02/06/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;
using System.Collections;
namespace Lab11
{
    public class CheatQueue : Queue 
    {
        public CheatQueue() : base () { }
        public CheatQueue(int capacity) : base() { }
        public CheatQueue(int capacity, float growFact) : base() { }
        public CheatQueue(ICollection collection) : base() { }
    }
}
