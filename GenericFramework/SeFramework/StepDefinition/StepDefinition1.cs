using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeFramework.Context.General;
using TechTalk.SpecFlow;

namespace SeFramework.StepDefinition
{
    [Binding]
    public sealed class StepDefinition1
    {
        private readonly ExecutionContext executionContext;
        public StepDefinition1(ExecutionContext context)
        {
            executionContext = context;
        }
    }
}
