using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SeFramework.Context.General;

namespace SeFramework.StepDefinition.Stef
{
    [Binding]
    public sealed class TricentisWebShop
    {
        private readonly ExecutionContext context;

        public TricentisWebShop(ExecutionContext execution)
        {
            context = execution;
        }  
    }
}
