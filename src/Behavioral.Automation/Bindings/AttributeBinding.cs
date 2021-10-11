﻿using System;
using System.Linq;
using Behavioral.Automation.Elements.Interfaces;
using Behavioral.Automation.FluentAssertions;
using Behavioral.Automation.Model;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace Behavioral.Automation.Bindings
{
    [Binding]
    public sealed class AttributeBinding
    {
        private readonly ITestRunner _runner;

        public AttributeBinding([NotNull] ITestRunner runner)
        {
            _runner = runner;
        }

        [Given("the (.*?) (is|is not|become| become not) (enabled|disabled)")]
        [When("the (.*?) (is|is not|become| become not) (enabled|disabled)")]
        [Then("the (.*?) should (be|be not|become|become not) (enabled|disabled)")]
        public void CheckElementIsDisabled(
            [NotNull] IWebElementWrapper element, 
            [NotNull] AssertionBehavior behavior, 
            bool enabled)
        {
            var status = enabled ? " not" : string.Empty;
            Assert.ShouldBecome(() => element.Enabled, enabled, behavior,
                $"{element.Caption} is{status} enabled");
        }

        [StepArgumentTransformation("(enabled|disabled)")]
        public bool ConvertEnabledState([NotNull] string enabled)
        {
            return enabled == "enabled";
        }

        [Then("the following controls should (be|be not|become|become not) (enabled|disabled):")]
        public void CheckThenControlTypeCollectionShown([NotNull] string behavior, string enabled, [NotNull] Table table)
        {
            behavior = $"should {behavior}";
            CheckControlTypeCollectionEnabled(behavior, enabled, table, _runner.Then);
        }

        [Given("the following controls (are|are not|become| become not) (enabled|disabled):")]
        [When("the following controls (are|are not|become| become not) (enabled|disabled):")]
        public void CheckGivenControlTypeCollectionEnabled([NotNull] string behavior, string enabled, [NotNull] Table table)
        {
            if (behavior.Contains("are"))
            {
                behavior = behavior.Replace("are", "is");
            }
            CheckControlTypeCollectionEnabled(behavior, enabled, table, _runner.Given);
        }

        private void CheckControlTypeCollectionEnabled(
            [NotNull] string behavior, 
            string enabled,
            [NotNull] Table table,
            [NotNull] Action<string> runnerAction)
        {
            foreach (var row in table.Rows)
            {
                var control = "the \"" + row.Values.First() + "\" " + row.Values.Last();
                runnerAction($"{control} {behavior} {enabled}");
            }
        }
    }
}
